using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
     class AnalogDisplay : BaseDisplay
    {
        private AnalogClock myForm = new AnalogClock();

        public AnalogDisplay()
        {
            SingletonClock.Instance.attach(this);
           
        }

        ~AnalogDisplay()
        {
            this.exit();
        }

        public override void update()
        {
            myForm.clockControl1.myTime = SingletonClock.Instance.GetTime;
           // displayTime = SingletonClock.Instance.GetTime;
            //SingletonClock.Instance.GetTime = DateTime; //setter
        }

        public override void show()
        {
            myForm.Show();
        }

        public override void exit()
        {
            myForm.Close();
            SingletonClock.Instance.detach(this);
        }
    }
}
