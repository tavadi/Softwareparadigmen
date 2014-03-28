using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdDec : BaseCommand
    {
        private SingletonClock _clock;

        public CmdDec(SingletonClock receiver)
        {
            _clock = receiver;
        }
        public void Execute(Command cmd)
        {
            _clock.Decrease(cmd);
        }


        public void Undo(Command cmd)
        {
            _clock.Increase(cmd);
        }
    }
}
