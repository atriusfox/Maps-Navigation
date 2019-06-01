using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maps_Navigation
{
    class Position : IPosition
    {
        Orientation orientation { get; set; }
        int x { get; set; }
        int y { get; set; }
        public Position()
        {
            x = 0;
            y = 0;
            orientation = Orientation.North;
        }

        public Position(int xStart, int yStart, Orientation orientationStart)
        {
            x = xStart;
            y = yStart;
            orientation = orientationStart;
        }

        public Position(Point xyStart, Orientation orientationStart)
        {
            x = xyStart.X;
            y = xyStart.Y;
            orientation = orientationStart;
        }

        public Orientation RotateRight()
        {
            switch (orientation)
            {
                case Orientation.North:
                    orientation = Orientation.East;
                    break;
                case Orientation.East:
                    orientation = Orientation.South;
                    break;
                case Orientation.South:
                    orientation = Orientation.West;
                    break;
                case Orientation.West:
                    orientation = Orientation.North;
                    break;
            }
            return orientation;
        }

        public Orientation RotateLeft()
        {
            switch (orientation)
            {
                case Orientation.North:
                    orientation =  Orientation.West;
                    break;
                case Orientation.West:
                    orientation =  Orientation.South;
                    break;
                case Orientation.South:
                    orientation =  Orientation.East;
                    break;
                case Orientation.East:
                    orientation =  Orientation.North;
                    break;
            }
            return orientation;
        }
        public void MoveForward(int steps)
        { 
            switch (orientation)
            {
                case Orientation.North:
                    y = checked (y + steps);
                    break;
                case Orientation.South:
                    y = checked (y - steps);
                    break;
                case Orientation.East:
                    x = checked (x + steps);
                    break;
                case Orientation.West:
                    x = checked (x - steps);
                    break;
            }
        }

        public Point GetPosition()
        {
            return new Point(x, y);
        }        

        public Orientation GetOrientation()
        {
            return orientation;
        }
    }
}
