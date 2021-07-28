using System.Drawing;

namespace Worms.GameEngine
{
    public class Apple
    {
        private static int _guid = 0;

        public Apple(Point location)
        {
            Location = location;
            Id = _guid++;
        }

        public Point Location { get; private set; }

        public int Id { get; private set; }
    }
}
