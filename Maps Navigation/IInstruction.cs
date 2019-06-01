using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps_Navigation
{
    interface IInstruction
    {
        void Execute(IPosition position);
    }
}
