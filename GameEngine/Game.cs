using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worms.GameEngine.Enums;

namespace Worms.GameEngine
{
    class Game
    {
        private const int
            FIELD_SIZE = 20,
            INITIAL_NUMBER_OF_WORMS = 5,
            ESCAPE_NUMBER_OF_WORMS = 2,
            ADJUNCTION_NUMBER_OF_WORMS = 3;

        private const double
            ESCAPE_BORDER = 0.05,
            ADJUNCTION_BORDER = 0.2;


        private GameForm _gameForm;

        private ILogger _logger;

        private Random _random = new Random();

        private List<Worm> _worms = new List<Worm>();

        private List<Apple> _apples = new List<Apple>();

        public Game(GameForm gameForm, ILogger logger)
        {
            _gameForm = gameForm;
            _logger = logger;
            Status = GameStatus.Inactive;
            Speed = GameSpeed.VeryFast;
        }

        public GameStatus Status { get; private set; }

        public GameSpeed Speed { get; set; }

        #region game actions

        public async void Start()
        {
            Status = GameStatus.Active;
            _logger.GameStarted(DateTime.Now);
            _gameForm.CreateField(FIELD_SIZE);

            await SeedAsync();

            while (Status == GameStatus.Active) await StepAsync();
        }

        public void Stop()
        {
            Status = GameStatus.Stopped;
            _logger.GameStopped(DateTime.Now);
        }

        private void Seed()
        {
            AddWorms(INITIAL_NUMBER_OF_WORMS);

            AddApples(_random.Next((int)(FIELD_SIZE * FIELD_SIZE * ESCAPE_BORDER), (int)(FIELD_SIZE * FIELD_SIZE * ADJUNCTION_BORDER)));

            _gameForm.Invoke(_gameForm.SetTextDelegate, new object[] { GetInfo() });

            Delay();
        }

        private async Task SeedAsync()
        {
            await Task.Run(() => Seed());
        }

        private void Step()
        {
            if (_apples.Count < FIELD_SIZE * FIELD_SIZE * ESCAPE_BORDER)
            {
                RemoveWorms(ESCAPE_NUMBER_OF_WORMS);
            }
            else if (_apples.Count > FIELD_SIZE * FIELD_SIZE * ADJUNCTION_BORDER)
            {
                AddWorms(ADJUNCTION_NUMBER_OF_WORMS);
            }

            MoveWorms();

            AddApples(_random.Next((int)(FIELD_SIZE * FIELD_SIZE * ESCAPE_BORDER)));

            _gameForm.Invoke(_gameForm.SetTextDelegate, new object[] { GetInfo() });

            Delay();
        }

        private async Task StepAsync()
        {
            await Task.Run(() => Step());
        }

        private MoveDirection GetMoveDirection(Point wormLocation, Point appleLocation)
        {
            Point offset = new Point(wormLocation.X - appleLocation.X, wormLocation.Y - appleLocation.Y);

            // червяк правее яблока
            if (offset.X > 0)
            {
                // червяк ниже яблока
                if (offset.Y > 0) return MoveDirection.UpLeft;

                // червяк выше яблока
                if (offset.Y < 0) return MoveDirection.DownLeft;

                // червяк на одном уровне с яблоком
                return MoveDirection.Left;
            }

            // червяк левее яблока
            if (offset.X < 0)
            {
                // червяк ниже яблока
                if (offset.Y > 0) return MoveDirection.UpRight;

                // червяк выше яблока
                if (offset.Y < 0) return MoveDirection.DownRight;

                // червяк на одном уровне с яблоком
                return MoveDirection.Right;
            }

            // червяк на одной вертикали с яблоком и ниже яблока
            if (offset.Y > 0) return MoveDirection.Up;

            // червяк на одной вертикали с яблоком и выше яблока
            return MoveDirection.Down;
        }

        private int GetDist(Point point1, Point point2) => Math.Max(Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));

        private Point GetRandomPoint() => new Point(_random.Next(FIELD_SIZE), _random.Next(FIELD_SIZE));

        private Point GetFreePoint()
        {
            Point point;

            var wormPoints = _worms.Select(w => w.Location);

            var applePoints = _apples.Select(a => a.Location);

            do
            {
                point = GetRandomPoint();
            }
            while (wormPoints.Contains(point) || applePoints.Contains(point));

            return point;
        }

        private string GetInfo() => $"Worms and Apples {{Worms = {_worms.Count}; Apples = {_apples.Count}}}";

        private void Delay()
        {
            int times = (int)Speed / 100;

            for (int i = 0; i < times; i++, times = (int)Speed / 100)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        #endregion

        #region worms actions

        private void AddWorms(int number)
        {
            for (int i = 0; i < number; i++) AddWorm();
        }

        private void AddWorm()
        {
            Worm worm = new Worm(GetFreePoint());
            _worms.Add(worm);
            _logger.WormAdded(DateTime.Now, worm.Id, worm.Location);
            _gameForm.Invoke(_gameForm.AddWormDelegate, new object[] { worm.Location });
        }

        private void RemoveWorms(int number)
        {
            for (int i = 0; i < number; i++)
            {
                if (_worms.Count > 0) RemoveWorm(_worms[_random.Next(_worms.Count)]);
                else
                {
                    Status = GameStatus.Ended;
                    _logger.GameEnded(DateTime.Now);
                    _gameForm.Invoke(_gameForm.GameOverDelegate);
                    return;
                }
            }
        }

        private void RemoveWorm(Worm worm)
        {
            _worms.Remove(worm);
            _logger.WormRemoved(DateTime.Now, worm.Id, worm.Location);
            _gameForm.Invoke(_gameForm.RemoveWormDelegate, new object[] { worm.Location });
        }

        private void MoveWorms()
        {
            foreach (var worm in _worms) MoveWorm(worm);
        }

        private void MoveWorm(Worm worm)
        {
            Point oldWormLocation = worm.Location;

            Apple nearestApple = FindNearestApple(worm.Location);

            worm.Move(GetMoveDirection(worm.Location, nearestApple.Location));

            if (worm.Location == nearestApple.Location)
            {
                RemoveApple(nearestApple);
                _logger.WormAteApple(DateTime.Now, worm.Id, oldWormLocation, worm.Location, nearestApple.Id);
            }
            else _logger.WormMoved(DateTime.Now, worm.Id, oldWormLocation, worm.Location);

            _gameForm.Invoke(_gameForm.MoveWormDelegate, new object[] { oldWormLocation, worm.Location });
        }

        #endregion

        #region apples actions

        private void AddApples(int number)
        {
            for (int i = 0; i < number; i++) AddApple();
        }

        private void AddApple()
        {
            Apple apple = new Apple(GetFreePoint());
            _apples.Add(apple);
            _logger.AppleAdded(DateTime.Now, apple.Id, apple.Location);
            _gameForm.Invoke(_gameForm.AddAppleDelegate, new object[] { apple.Location });
        }

        private void RemoveApple(Apple apple)
        {
            _apples.Remove(apple);
        }

        private Apple FindNearestApple(Point wormLocation)
        {
            var applePoints = _apples.Select(a => a.Location);

            int min = GetDist(wormLocation, applePoints.First());

            foreach (var point in applePoints)
            {
                int dist = GetDist(wormLocation, point);
                if (dist < min) min = dist;
            }

            var result = _apples.Where(a => GetDist(wormLocation, a.Location) == min).ToList();

            return result[_random.Next(result.Count)];
        }

        #endregion   
    }
}
