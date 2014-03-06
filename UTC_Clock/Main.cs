using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DigitalDisplay mydisplay = new DigitalDisplay();
            SingletonClock.Instance.notifyObservers();
        }
    }
}
