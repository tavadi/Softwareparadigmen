using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace UTC_Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalogClock myForm = new AnalogClock();
            myForm.Show();
            Application.Run();
            DigitalDisplay mydisplay = new DigitalDisplay();
            SingletonClock.Instance.notifyObservers();
           // System.Threading.Thread.Sleep(3000);
            Console.ReadLine();
            
        }

        public void clockstart()
        {
            AnalogClock myForm = new AnalogClock();
            myForm.Show();
        }
    }
}
