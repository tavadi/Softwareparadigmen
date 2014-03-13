using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
     class AnalogDisplay : BaseDisplay
    {

        public DateTime displayTime;

        public AnalogDisplay()
        {
            AnalogClock myForm = new AnalogClock();
            myForm.Show();
            myForm.clockControl1.myTime = SingletonClock.Instance.GetTime;
            SingletonClock.Instance.attach(this); // fragen ob das richtig ist
        }

        public override void update()
        {
            displayTime = SingletonClock.Instance.GetTime;
            //SingletonClock.Instance.GetTime = DateTime; //setter
        }
    }
}
