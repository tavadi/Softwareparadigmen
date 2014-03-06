using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    public abstract class BaseCommand
    {
        public abstract void undo();
        public abstract void redo();
        public abstract void help();
       
    }
}
