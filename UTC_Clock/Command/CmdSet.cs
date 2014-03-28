using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdSet : BaseCommand
    {
        private SingletonClock _clock;

        public CmdSet(SingletonClock receiver)
        {
            _clock = receiver;
        }
        public void Execute(Command cmd)
        {
            _clock.Set(cmd);
        }


        public void Undo(Command cmd)
        {
            _clock.undoSet();
        }
    }
}
