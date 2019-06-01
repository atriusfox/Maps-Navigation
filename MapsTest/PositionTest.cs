using System;
using Xunit;
using System.Drawing;
using Maps_Navigation;

namespace MapsTest
{
    public class PositionTests
    {
        Position position;

        public PositionTests()
        {
            position = new Position();
        }

        [Fact]
        public void No_Rotate()
        {
            Orientation check = Orientation.North;
            Assert.True(check == position.GetOrientation());
        }

        #region RotateLeft
        [Fact]
        public void Rotate_Left()
        {
            Orientation check = Orientation.West;
            position.RotateLeft();
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Left_Twice()
        {
            Orientation check = Orientation.South;
            for (int i = 0; i < 2; i++)
            {
                position.RotateLeft();
            }
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Left_Three()
        {
            Orientation check = Orientation.East;
            for (int i = 0; i < 3; i++)
            {
                position.RotateLeft();
            }
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Left_Four()
        {
            Orientation check = Orientation.North;
            for (int i = 0; i < 4; i++)
            {
                position.RotateLeft();
            }
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Left_Five()
        {
            Orientation check = Orientation.West;
            for(int i = 0; i < 5; i++)
            {
                position.RotateLeft();
            }
            Assert.True(check == position.GetOrientation());
        }
        #endregion

        #region RotateRight
        [Fact]
        public void Rotate_Right()
        {
            Orientation check = Orientation.East;
            position.RotateRight();
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Right_Twice()
        {
            Orientation check = Orientation.South;
            for (int i = 0; i < 2; i++)
            {
                position.RotateRight();
            }
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Right_Three()
        {
            Orientation check = Orientation.West;
            for (int i = 0; i < 3; i++)
            {
                position.RotateRight();
            }
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Right_Four()
        {
            Orientation check = Orientation.North;
            for (int i = 0; i < 4; i++)
            {
                position.RotateRight();
            }
            Assert.True(check == position.GetOrientation());
        }

        [Fact]
        public void Rotate_Right_Five()
        {
            Orientation check = Orientation.East;
            for (int i = 0; i < 5; i++)
            {
                position.RotateRight();
            }
            Assert.True(check == position.GetOrientation());
        }
        #endregion

        #region Move Forward out of Bounds
        [Fact]
        public void Move_North_Out_Of_Bounds()
        {
            position.MoveForward(int.MaxValue);

            Assert.Throws<OverflowException>(() => position.MoveForward(1));
        }

        [Fact]
        public void Move_East_Out_Of_Bounds()
        {
            position.RotateRight();
            position.MoveForward(int.MaxValue);

            Assert.Throws<OverflowException>(() => position.MoveForward(1));
        }
        [Fact]
        //We have to move MAX int plus 2 when moving negatively on the grid to cause overflow (int.Min vs int.max)
        public void Move_South_Out_Of_Bounds()
        {
            position.RotateRight();
            position.RotateRight();
            position.MoveForward(int.MaxValue);

            Assert.Throws<OverflowException>(() => position.MoveForward(2));
        }
        [Fact]
        //We have to move MAX int plus 2 when moving negatively on the grid to cause overflow (int.Min vs int.max)
        public void Move_West_Out_Of_Bounds()
        {
            position.RotateLeft();
            position.MoveForward(int.MaxValue);

            Assert.Throws<OverflowException>(() => position.MoveForward(2));
        }

        #endregion

        #region Move Forward all Directions
        [Fact]
        public void Move_North()
        {
            position.MoveForward(10);
            Point p = new Point(0, 10);
            Assert.Equal<Point>(p, position.GetPosition());
        }

        [Fact]
        public void Move_East()
        {
            position.RotateRight();
            position.MoveForward(10);
            Point p = new Point(10, 0);
            Assert.Equal<Point>(p, position.GetPosition());
        }
        [Fact]
        public void Move_West()
        {
            position.RotateLeft();
            position.MoveForward(10);
            Point p = new Point(-10, 0);
            Assert.Equal<Point>(p, position.GetPosition());
        }

        [Fact]
        public void Move_South()
        {
            position.RotateRight();
            position.RotateRight();
            position.MoveForward(10);
            Point p = new Point(0, -10);
            Assert.Equal<Point>(p, position.GetPosition());
        }
        #endregion

    }
}
