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
        private List<Command> _commandParamterHistory = new List<Command>();
        private int currentPos = 0;
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
                try
                {
                    switch (myCommand.commandType)
                    {
                        case "set":
                            myCommandObj = new CmdSet(SingletonClock.Instance);
                            _commandParamterHistory.Add(myCommand);
                            currentPos++;
                            break;
                        case "help":
                            myCommandObj = new CmdHelp();
                            break;
                        case "dec":
                            myCommandObj = new CmdDec(SingletonClock.Instance);
                            _commandParamterHistory.Add(myCommand);
                            currentPos++;
                            break;
                        case "inc":
                            myCommandObj = new CmdInc(SingletonClock.Instance);
                            _commandParamterHistory.Add(myCommand);
                            currentPos++;
                            break;
                        case "undo":
                            myCommandObj = new CmdUndo(_commandParamterHistory[currentPos - 1]);
                            currentPos--;
                            break;
                        case "redo"://wiederholt den letzten Befehl oder macht das letzte undo wieder rückgängig
                            Console.WriteLine("redoing not implemented yet");
                            break;
                        case "show":
                            // myCommandObj = new CmdShow(BaseDisplay receiver);
                            break;
                        default:
                            break;
                    }

                    myCommandObj.Execute(myCommand);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("no more undo");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("No command to execute");
                }
            }
        }
    }
}
