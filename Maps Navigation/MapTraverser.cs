using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maps_Navigation
{
    enum Orientation
        {
            North,
            East,
            South,
            West
        }
    class MapTraverser
    {
        Position position;
        public MapTraverser()
        {
            position = new Position();
        }

        //receive list of comma delimited instructions
        public void Traverse(string instructions)
        {
            string[] instructionList = instructions.Split(',');
            foreach (string instruction in instructionList.Select(x => x.Trim()))
            {
                MapInstruction inst = new MapInstruction(instruction);
                inst.Execute(position);                
            }
        }

        public int GetDistanceFromStart()
        {
            Point p = position.GetPosition();
            return checked (Math.Abs(p.X) + Math.Abs(p.Y));
        }
    }
}
