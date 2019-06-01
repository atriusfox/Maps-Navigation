using System;
using Xunit;
using Maps_Navigation;

namespace MapsTest
{
    public class MapInstructionTest

    {
        MapInstruction instruction;
        Position position;
        public MapInstructionTest()
        {
            position = new Position();
        }
        [Fact]
        public void Empty_String_Passed()
        {
            Assert.Throws<ArgumentException>(() => new MapInstruction(""));
        }

        [Fact]
        public void Malformed_Instruction()
        {
            Assert.Throws<ArgumentException>(() => new MapInstruction("RR2"));
        }
        [Fact]
        public void Not_An_Instruction()
        {
            Assert.Throws<ArgumentException>(() => new MapInstruction("This is not an instruction!"));
        }

        [Fact]
        public void Lowercase_Not_allowed()
        {
            Assert.Throws<ArgumentException>(() => new MapInstruction("l2"));
        }

        [Fact]
        public void Steps_Larger_Than_Int()
        {
            Assert.Throws<ArgumentException>(() => new MapInstruction("L2000000000000000000000000000000"));
        }

        [Fact]
        public void Execute_L2()
        {
            instruction = new MapInstruction("L2");
            instruction.Execute(position);
            Assert.True(position.GetOrientation() == Orientation.West && position.GetPosition().X == -2 && position.GetPosition().Y == 0);
        }

        [Fact]
        public void Execute_R1()
        {
            instruction = new MapInstruction("R1");
            instruction.Execute(position);
            Assert.True(position.GetOrientation() == Orientation.East && position.GetPosition().X == 1 && position.GetPosition().Y == 0);
        }

    }
}
