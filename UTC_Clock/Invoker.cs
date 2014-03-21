using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    public class Invoker
    {
        BaseCommand newCommand;

        public Invoker(BaseCommand myCommand)
        {
            newCommand = myCommand;
        }

        public void Invoke()
        {
            newCommand.Execute();
        }
    }
}
