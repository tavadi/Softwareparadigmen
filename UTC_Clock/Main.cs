using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace UTC_Clock
{
    class Program
    {
        static void Main(string[] args)
        {
        AnalogDisplay myAnalog = new AnalogDisplay();
        DigitalDisplay mydisplay = new DigitalDisplay();
        SingletonClock.Instance.notifyObservers();
        //Console.ReadLine();
        Application.Run();
        }
    }
}
