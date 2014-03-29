using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{   //Erstellt Paramter für Command
    public class Command //Splitted Form Input und holt sich die nötigen Paramter
    {
        public  bool undoBool = false; //wurde das objekt schon undo´t
        public string commandType { get; set; } // typ des Befehls(Set,Inc,Dec,Show...)
        public List<string> parameter = new List<string>();

        public Command(string newCommand)
        {
            commandType = newCommand;
            string[] splitted = commandType.Split();
            commandType = splitted[0]; //Typ des Befehls wird gespeichert(CmdSet/CmdDec ...)
         
            foreach (var e in splitted)
            {
                if (e != splitted[0])
                {
                    parameter.Add(e); //Fügt Paramter einer Liste hinzu
                }
            }
        }
    }
}
