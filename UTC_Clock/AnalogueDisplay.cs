using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    class AnalogueDisplay : BaseDisplay
    {
        private DateTime displayTime;

        public AnalogueDisplay()
        {
            SingletonClock.Instance.attach(this);
        }
        public override void update()
        {
            displayTime = SingletonClock.Instance.getTime();
        }
    }
}
