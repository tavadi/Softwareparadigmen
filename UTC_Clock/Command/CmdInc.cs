using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdInc : BaseCommand
    {
        #region Command Pattern Logic
        private SingletonClock _clock;

        public CmdInc(SingletonClock receiver)
        {
            _clock = receiver;
        }
        public void Execute(Command cmd)
        {
            _clock.Increase(cmd);
        }


        public void Undo(Command cmd)
        {
            _clock.Decrease(cmd);
        }
        #endregion
    }
}
