using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worms.GameEngine;

namespace Worms.GameEngine
{
    public interface ILogger
    {
        string LogFilePath { get; }

        void GameStarted(DateTime time);

        void GameEnded(DateTime time);

        void GameStopped(DateTime time);

        void WormAdded(DateTime time, int wormId, Point location);

        void AppleAdded(DateTime time, int appleId, Point location);

        void WormRemoved(DateTime time, int wormId, Point location);

        void WormMoved(DateTime time, int wormId, Point oldLocation, Point newLocation);

        void WormAteApple(DateTime time, int wormId, Point oldLocation, Point newLocation, int appleId);
    }
}
