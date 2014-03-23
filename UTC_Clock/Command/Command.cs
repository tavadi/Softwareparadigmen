using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class Command //Splitted Form Input und holt sich die nötigen Paramter
    {
        public string commandType { get; set; }
        public Dictionary<string, string> parameter = new Dictionary<string, string>();    
  

        public Command(string newCommand)
        {
            commandType = newCommand;
            string[] splitted = commandType.Split();
            commandType = splitted[0]; //Typ des Befehls wird gespeichert(CmdSet/CmdDec ...)
            //Console.WriteLine(commandType);
            for (int i = 1; i < splitted.Length; i += 2)
            {
                parameter.Add(splitted[i], splitted[i + 1]); //Paramter werden gespeichert ( set {–h <hour>} {-m <minutes>} {-s <seconds>}) !! beliebige reihenfolge der paramter möglich
            }
        }
    }
}
