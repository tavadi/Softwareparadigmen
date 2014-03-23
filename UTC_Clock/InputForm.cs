using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTC_Clock
{
    public partial class InputForm : Form // INVOKER
    {

        private List<BaseCommand> _commandHistory = new List<BaseCommand>();
        public InputForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            BaseCommand myCommandObj = null;
            Command myCommand = new Command(textBox1.Text);
             
               switch (myCommand.commandType)
               {
                   case "set":
                       myCommandObj = new CmdSet();
                       break;
                   case "help":
                       myCommandObj = new CmdHelp();
                       break;
                   case "dec":
                       myCommandObj = new CmdDec(SingletonClock.Instance);
                       break;
                   case "inc":
                       myCommandObj = new CmdInc();
                       break;
                   case "undo":
                       Console.WriteLine("undoing not implemented yet");
                       break;
                   case "redo":
                       Console.WriteLine("redoing not implemented yet");
                       break;
                   case "show":
                       myCommandObj = new CmdSet();
                       break;
                   default:
                       break;
               }
               _commandHistory.Add(myCommandObj);
               myCommandObj.Execute(myCommand);
            }
        }
    }
}
