﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UTC_Clock
{
    class DigitalDisplay : BaseDisplay //konkrete Beobachter
    {
        private DigitalClock myForm = new DigitalClock();

        public DigitalDisplay()
        {
            SingletonClock.Instance.attach(this);
        }

       
        ~DigitalDisplay()
        {
            this.exit();
        }

        public override void update()
        {
           myForm.myTime = SingletonClock.Instance.GetTime;
        }

        public override void show()
        {
            myForm.Show();
        }

        public override void exit()
        {
            myForm.Close();
        }
    }
}
