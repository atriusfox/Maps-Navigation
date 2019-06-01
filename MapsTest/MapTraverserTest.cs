using System;
using Xunit;
using Maps_Navigation;

namespace MapsTest
{
    public class MapTraverserTest
    {
        MapTraverser map;
        public MapTraverserTest()
        {
            map = new MapTraverser();
        }

        [Fact]
        public void Traverse_Example1()
        {
            map.Traverse("L3, R2, L5, R1, L1, L2");
            Assert.Equal(10, map.GetDistanceFromStart());
        }

        [Fact]
        public void Traverse_Example1_With_Lots_Of_Spaces()
        {
            map.Traverse("          L3   , R2  , L5, R1, L1, L2  ");
            Assert.Equal(10, map.GetDistanceFromStart());
        }

        [Fact]
        public void Traverse_Example1_Bad_Spaces()
        {
            Assert.Throws<ArgumentException>(() => map.Traverse("L 3, R2, L5, R1, L1, L2"));
        }

        [Fact]
        public void Traverse_Example2()
        {
            map.Traverse("L3, R2, L5, R1, L1, L2, L2, R1, R5, R1, L1, L2, R2, R4, L4, L3, L3, R5, L1, R3, L5, L2, R4, L5, R4, R2, L2, L1, R1, L3, L3, R2, R1, L4, L1, L1, R4, R5, R1, L2, L1, R188, R4, L3, R54, L4, R4, R74, R2, L4, R185, R1, R3, R5, L2, L3, R1, L1, L3, R3, R2, L3, L4, R1, L3, L5, L2, R2, L1, R2, R1, L4, R5, R4, L5, L5, L4, R5, R4, L5, L3, R4, R1, L5, L4, L3, R5, L5, L2, L4, R4, R4, R2, L1, L3, L2, R5, R4, L5, R1, R2, R5, L2, R4, R5, L2, L3, R3, L4, R3, L2, R1, R4, L5, R1, L5, L3, R4, L2, L2, L5, L5, R5, R2, L5, R1, L3, L2, L2, R3, L3, L4, R2, R3, L1, R2, L5, L3, R4, L4, R4, R3, L3, R1, L3, R5, L5, R1, R5, R3, L1");
            Assert.Equal(209, map.GetDistanceFromStart());
        }

        [Fact]
        public void Distance_Larger_Than_Int()
        {
            map.Traverse("L2000000000, R2000000000");
            Assert.Throws<OverflowException>(() => map.GetDistanceFromStart());
        }
    }
}
