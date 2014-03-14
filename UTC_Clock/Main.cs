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
           
            //DigitalDisplay mydisplay = new DigitalDisplay();
         //   Console.WriteLine("test");
                  SingletonClock.Instance.notifyObservers();
           // System.Threading.Thread.Sleep(3000);
          //  Console.ReadLine();
           Application.Run();
        }
    }
}
