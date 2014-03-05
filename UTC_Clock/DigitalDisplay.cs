using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{

    
    class DigitalDisplay : BaseDisplay
    {
        private DateTime displayTime;

        public DigitalDisplay()
        {
            SingletonClock.Instance.attach(this);
        }
        public override void update()
        {
            displayTime = SingletonClock.Instance.getTime();
        }
    }
}
