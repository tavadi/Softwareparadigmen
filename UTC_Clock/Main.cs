using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace UTC_Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            InputForm myInputForm = new InputForm();
            myInputForm.Show();
           // DigitalDisplay mydisplay = new DigitalDisplay();
            //AnalogDisplay myAnalog = new AnalogDisplay();
            Application.Run();
        }
    }
}
