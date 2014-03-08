using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class DigitalDisplay : BaseDisplay //konkrete Beobachter
    {
        private DateTime displayTime;

        public DigitalDisplay()
        {
            SingletonClock.Instance.attach(this); // fragen ob das richtig ist
        }
        public override void update()
        {
            displayTime = SingletonClock.Instance.GetTime;
            //SingletonClock.Instance.GetTime = DateTime; //setter
        }
        public void show()//nicht sicher(rene sagt es gehoert so )
        {
            //
        }
    }
}
