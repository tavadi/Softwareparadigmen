using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{

    class AnalogDisplay : BaseDisplay   //konkrete Beobachter
    {
        private AnalogClock myForm = null;
        private Command myCmd;
        private int myTimeZone;
        private int myPosX;
        private int myPosY;

        public AnalogDisplay(Command myCommandObj)
        {
           
            myCmd = myCommandObj;
            for (int i = 0; i < myCmd.parameter.Count; i++)
            {
                switch (myCmd.parameter[i])
                {
                    case "-z":
                        myTimeZone = Convert.ToInt32(myCmd.parameter[i + 1]);
                        break;
                    case "-x":
                        myPosX = Convert.ToInt32(myCmd.parameter[i + 1]);
                        break;
                    case "-y":
                        myPosY = Convert.ToInt32(myCmd.parameter[i + 1]);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("posX: " + myPosX + " posY: " + myPosY);
            myForm = new AnalogClock(myPosX, myPosY);
            SingletonClock.Instance.attach(this);
            Console.WriteLine("myTimezone" + myTimeZone);
        }

   
        ~AnalogDisplay()
        {
            this.exit();
        }


        public override void update()
        {
            myForm.clockControl1.myTime = SingletonClock.Instance.GetTime + TimeSpan.Parse(myTimeZone + ":00:00");
           // displayTime = SingletonClock.Instance.GetTime;
            //SingletonClock.Instance.GetTime = DateTime; //setter
        }

        //show –t <type> {-z <timezone>} {-x <x> -y <y>}
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
