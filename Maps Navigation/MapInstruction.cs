using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps_Navigation
{
    class MapInstruction : IInstruction
    {
        private string instructionRef;
        public MapInstruction(string instruction)
        {
            if (instruction == String.Empty)
                throw new ArgumentException("Instruction cannot be blank.");
            if (!IsValidInstructionString(instruction))
                throw new ArgumentException($"Invalid Instruction '{instruction}' in input");
            instructionRef = instruction;
        }
        public void Execute(IPosition position)
        {
                if (instructionRef.StartsWith("L"))
                    position.RotateLeft();
                else
                    position.RotateRight();

                position.MoveForward(int.Parse(instructionRef.Substring(1)));
        }
        private bool IsValidInstructionString(string instruction)
        {
            return (instruction.StartsWith("L") || instruction.StartsWith("R")) 
                    && instruction.Substring(1).All(x => char.IsDigit(x))
                    && int.TryParse(instruction.Substring(1), out int n);
        }
    }
}
