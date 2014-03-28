using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdShow : BaseCommand
    {
        private BaseDisplay _myDisplay = null;

        public CmdShow(BaseDisplay receiver)
        {
            _myDisplay = receiver;
        }

        public void Execute(Command cmd)
        {
            _myDisplay.show();
        }

        public void Undo(Command cmd)
        {
            _myDisplay.exit();
        }
    }
}
