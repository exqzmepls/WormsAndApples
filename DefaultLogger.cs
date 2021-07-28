using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worms.GameEngine;

namespace Worms
{
    public class DefaultLogger : ILogger
    {
        public string LogFilePath { get; private set; }

        public DefaultLogger(string logFilePath = "WormsAndApples_log.txt")
        {
            LogFilePath = logFilePath;
        }

        public void GameStarted(DateTime time)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - New game was started.");
            }
        }

        public void GameEnded(DateTime time)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - The game was ended.\n");
            }
        }

        public void GameStopped(DateTime time)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - The game was stopped.\n");
            }
        }

        public void WormAdded(DateTime time, int wormId, Point location)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - The worm#{wormId} was added at {location}.");
            }
        }

        public void AppleAdded(DateTime time, int appleId, Point location)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - The apple#{appleId} was added at {location}.");
            }
        }

        public void WormRemoved(DateTime time, int wormId, Point location)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - The worm#{wormId} was removed from {location}.");
            }
        }

        public void WormMoved(DateTime time, int wormId, Point oldLocation, Point newLocation)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - The worm#{wormId} moved from {oldLocation} to {newLocation}.");
            }
        }

        public void WormAteApple(DateTime time, int wormId, Point oldLocation, Point newLocation, int appleId)
        {
            using (StreamWriter stream = new StreamWriter(LogFilePath, true))
            {
                stream.WriteLine($"{time}.{time.Millisecond} - The worm#{wormId} moved from {oldLocation} to {newLocation} and ate the apple#{appleId}.");
            }
        }
    }
}
