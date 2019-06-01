using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maps_Navigation
{
    interface IPosition
    {
        void MoveForward(int steps);
        Orientation RotateLeft();
        Orientation RotateRight();
        Point GetPosition();
        Orientation GetOrientation();
        
    }
}
