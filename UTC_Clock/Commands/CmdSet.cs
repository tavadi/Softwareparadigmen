using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock.Commands
{
    class CmdSet : BaseCommand
    {
        public override void undo() 
        { 
            Console.WriteLine("bla"); 
        }
        public override void redo() 
        { 
            Console.WriteLine("bla"); 
        }
        public override void help() 
        { 
            Console.WriteLine("bla"); 
        }
    }
}
