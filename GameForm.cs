using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Worms.GameEngine;
using Worms.GameEngine.Enums;

namespace Worms
{
    public partial class GameForm : Form
    {
        private const int CELL_SIZE = 40;
        private const int DEFAULT_SPEED_INDEX = 2;

        private ILogger _logger = new DefaultLogger();
        
        private Game _game;

        private PictureBox[,] _field;

        private readonly GameSpeed[] speedModes = new GameSpeed[] { GameSpeed.VerySlow, GameSpeed.Slow, GameSpeed.Normal, GameSpeed.Fast, GameSpeed.VeryFast };

        public delegate void MoveWorm(Point oldLocation, Point newLocation);
        public MoveWorm MoveWormDelegate;
        public delegate void AddWorm(Point location);
        public AddWorm AddWormDelegate;
        public delegate void AddApple(Point location);
        public AddApple AddAppleDelegate;
        public delegate void RemoveWorm(Point location);
        public RemoveWorm RemoveWormDelegate;
        public delegate void SetText(string text);
        public SetText SetTextDelegate;
        public delegate void GameOver();
        public GameOver GameOverDelegate;

        public GameForm()
        {
            InitializeComponent();

            MoveWormDelegate = new MoveWorm(MoveWormMethod);
            AddWormDelegate = new AddWorm(AddWormMethod);
            AddAppleDelegate = new AddApple(AddAppleMethod);
            RemoveWormDelegate = new RemoveWorm(RemoveWormMethod);
            SetTextDelegate = new SetText(SetTextMethod);
            GameOverDelegate = new GameOver(GameOverMethod);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            restartToolStripButton.Enabled = false;
            stopToolStripButton.Enabled = false;

            speedToolStripComboBox.SelectedIndex = DEFAULT_SPEED_INDEX;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_game?.Status == GameStatus.Active)
            {
                if (MessageBox.Show("Are you sure you want to quit unfinished game?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    StopGame();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void startToolStripButton_Click(object sender, EventArgs e)
        {
            startToolStripButton.Enabled = false;
            restartToolStripButton.Enabled = true;
            stopToolStripButton.Enabled = true;

            StartGame();
        }

        private void restartToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restart the game?", "Restart", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                startToolStripButton.Enabled = false;
                restartToolStripButton.Enabled = true;
                stopToolStripButton.Enabled = true;

                StopGame();

                StartGame();
            }
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            startToolStripButton.Enabled = false;
            restartToolStripButton.Enabled = true;
            stopToolStripButton.Enabled = false;

            StopGame();

            MessageBox.Show("The game stopped.");
        }

        private void openLogFileToolStripButton_Click(object sender, EventArgs e)
        {
            Process.Start(_logger.LogFilePath);
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rulesToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The playing field has a size of 20 by 20 cells. A worm or an apple can occupy the cell.\n" +
                "The worms can move to other cells in all 8 directions in order to eat the apple closest to it (the worm's task is to eat as many apples as possible). " +
                "To eat the apple, the worm must occupy the cell in which the apple is located. Only one worm can eat one apple.\n" +
                "The game starts with 5 worms. From time to time, apples 'grow' on the field. " +
                "If apples occupy less than 5% of the field, then 2 worms go away from the field forever, in search of a more 'apple' place. " +
                "If apples occupy more than 20% of the field, then 3 new worms apear into the field.",
                "Rules");
        }

        private void GameOverMethod()
        {
            MessageBox.Show("Game over");

            startToolStripButton.Enabled = false;
            restartToolStripButton.Enabled = true;
            stopToolStripButton.Enabled = false;
        }

        private void StartGame()
        {
            _game = new Game(this, _logger) { Speed = speedModes[speedToolStripComboBox.SelectedIndex] };

            _game.Start();
        }

        private void StopGame()
        {
            _game.Stop();
        }

        public void CreateField(int size)
        {
            // Очищаем поле игры
            fieldPanel.Controls.Clear();

            // пустой массив картинок по размеру поля
            _field = new PictureBox[size, size];

            int y = fieldPanel.Height - CELL_SIZE;

            for (int j = 0; j < size; j++)
            {
                int x = 0;

                for (int i = 0; i < size; i++)
                {
                    // создаем новую картинку
                    PictureBox pic = new PictureBox
                    {
                        Image = Properties.Resources.FreeCell,
                        Location = new Point(x, y),
                        Size = new Size(CELL_SIZE, CELL_SIZE),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    // добавляем картинку на игровое поле
                    fieldPanel.Controls.Add(pic);
                    // запоминаем картинку на карте 
                    _field[i, j] = pic;

                    // смещаем координаты
                    x += CELL_SIZE;
                }
                // смещаем координаты
                y -= CELL_SIZE;
            }

            fieldPanel.Update();
        }

        private void AddWormMethod(Point location)
        {
            _field[location.X, location.Y].Image = Properties.Resources.Worm;
            fieldPanel.Update();
        }

        private void AddAppleMethod(Point location)
        {
            _field[location.X, location.Y].Image = Properties.Resources.Apple;
            fieldPanel.Update();
        }

        private void RemoveWormMethod(Point location)
        {
            _field[location.X, location.Y].Image = Properties.Resources.FreeCell;
            fieldPanel.Update();
        }

        private void MoveWormMethod(Point oldLocation, Point newLocation)
        {
            _field[oldLocation.X, oldLocation.Y].Image = Properties.Resources.FreeCell;
            _field[newLocation.X, newLocation.Y].Image = Properties.Resources.Worm;
            fieldPanel.Update();
        }

        private void SetTextMethod(string text)
        {
            Text = text;
        }

        private void speedToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_game != null) _game.Speed = speedModes[speedToolStripComboBox.SelectedIndex];
        }
    }
}
