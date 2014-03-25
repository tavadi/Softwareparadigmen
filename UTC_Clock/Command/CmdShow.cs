using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdShow : BaseCommand
    {
        private BaseDisplay _display;

        public CmdShow(BaseDisplay receiver)
        {
            _display = receiver;
        }
        public void Execute(Command cmd)
        {
           // _display.Show(cmd);
        }
    }
}
