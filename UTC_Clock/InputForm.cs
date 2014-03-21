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
    public partial class InputForm : Form
    {

        
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
                       break;
                   case "dec":
                       break;
                   case "inc":
                       break;
                   case "undo":
                       break;
                   case "redo":
                       break;
                   case "show":
                       break;
                   default:
                       break;
               }
               myCommandObj.Execute();
            }
        }
    }
}
