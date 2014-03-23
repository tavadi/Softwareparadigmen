using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    public class Command //Splitted Form Input und holt sich die nötigen Paramter
    {
        public string commandType { get; set; }
       // public Dictionary<string, string> parameter = new Dictionary<string, string>();    
        public List<string> parameter = new List<string>();

        public Command(string newCommand)
        {
            commandType = newCommand;
            string[] splitted = commandType.Split();
            commandType = splitted[0]; //Typ des Befehls wird gespeichert(CmdSet/CmdDec ...)
            //Console.WriteLine(commandType);
          /*  for (int i = 1; i < splitted.Length; i += 2)
                parameter.Add(splitted[i], splitted[i + 1]);
        
           */

          //  Console.WriteLine("length : " + splitted.Length);
            foreach(var e in splitted){
                if (e != splitted[0])
                {
                    parameter.Add(e);
                }
            }
          }
    }
}
