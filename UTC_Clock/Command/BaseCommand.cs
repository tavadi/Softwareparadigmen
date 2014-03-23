using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    interface BaseCommand
    {
        void Execute(Command cmd);
    }
}
