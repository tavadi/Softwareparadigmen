using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTC_Clock
{
    class CreateMacro
    {
        private List<string> list;
        public string parameter;
        public string commandType { get; set; }

        public CreateMacro(List<string> newList)
        {
            this.list = newList;
            commandType = list[0];
            foreach (var item in list)
            {
                if (item != commandType)
                {
                    parameter += item;
                    parameter += " ";
                }
            }
            MessageBox.Show("Created Macro: " + commandType + "\n" + parameter);

        }
    }
}
