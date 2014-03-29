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
        private Invoker myInvoker = null;
      
        public InputForm()
        {
            InitializeComponent();
            myInvoker = new Invoker();

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Immer wenn Enter gedrückt wurde, schicke Befehl an Invoker und führe den Befehl aus
                myInvoker.StoreAndExecute(textBox1.Text);
            }
        }
    }
}
