using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class CmdUndo : BaseCommand
    {
        private Command myCommand = null;

        public CmdUndo(Command cmd)
        {
           myCommand = cmd;
        }
        public void Execute(Command cmd)
        {
             BaseCommand myCommandObj = null;
            switch (myCommand.commandType)
            {
                case "set":
                   // myCommandObj = new CmdSet(SingletonClock.Instance);
                    break;
                case "dec":
                    myCommandObj = new CmdInc(SingletonClock.Instance);
                    break;
                case "inc":
                    myCommandObj = new CmdDec(SingletonClock.Instance);
                    break;
                case "redo"://wiederholt den letzten Befehl oder macht das letzte undo wieder rückgängig
                    Console.WriteLine("redoing not implemented yet");
                    break;
                default:
                    return;
            }
            myCommandObj.Execute(myCommand);
        }
    }
}