using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class DigitalDisplay : BaseDisplay //konkrete Beobachter
    {
        public DateTime displayTime;

        public DigitalDisplay()
        {
            SingletonClock.Instance.attach(this);
        }
        public override void update()
        {
            displayTime = SingletonClock.Instance.GetTime;

        }
        
        /*public void show()//nicht sicher(rene sagt es gehoert so )
        {
            //
        }
         * */
    }
}
