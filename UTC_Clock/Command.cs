using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class Command
    {
        public string myCommand { get; set; }
        public string commandType;

        Dictionary<string, int> dictionary =  new Dictionary<string, int>();
        public Invoker invoky;
        public Command(string newCommand)
        {
            myCommand = newCommand;
            string[] splitted = myCommand.Split();
            commandType = splitted[0];
            Console.WriteLine(commandType);
           
        }
     

    }
}
