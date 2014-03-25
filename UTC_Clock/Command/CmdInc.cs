using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdInc : BaseCommand
    {
        private SingletonClock _clock;

        public CmdInc(SingletonClock receiver)
        {
            _clock = receiver;
        }
        public void Execute(Command cmd)
        {
            _clock.Increase(cmd);
        }
    }
}
