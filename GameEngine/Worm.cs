using System.Drawing;
using Worms.GameEngine.Enums;

namespace Worms.GameEngine
{
    public class Worm
    {
        private static int _guid = 0;

        private Point _location; 

        public Worm(Point location)
        {
            _location = location;
            Id = _guid++;
        }

        public Point Location
        {
            get => _location;

            private set => _location = value;
        }

        public int Id { get; private set; }

        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.UpLeft:
                    _location.X--;
                    _location.Y--;
                    break;

                case MoveDirection.Up:
                    _location.Y--;
                    break;

                case MoveDirection.UpRight:
                    _location.X++;
                    _location.Y--;
                    break;

                case MoveDirection.Left:
                    _location.X--;
                    break;

                case MoveDirection.Right:
                    _location.X++;
                    break;

                case MoveDirection.DownLeft:
                    _location.X--;
                    _location.Y++;
                    break;

                case MoveDirection.Down:
                    _location.Y++;
                    break;

                case MoveDirection.DownRight:
                    _location.X++;
                    _location.Y++;
                    break;
            }
        }
    }
}
