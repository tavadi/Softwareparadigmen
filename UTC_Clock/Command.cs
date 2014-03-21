using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class Command
    {
        public string commandType { get; set; }
        public Dictionary<string, string> parameter = new Dictionary<string, string>();      
        public Command(string newCommand)
        {
            commandType = newCommand;
            string[] splitted = commandType.Split();
            commandType = splitted[0];
            Console.WriteLine(commandType);
                for (int i = 1; i < splitted.Length; i += 2)
                {
                    parameter.Add(splitted[i], splitted[i + 1]);
                }
        }
     

    }
}
