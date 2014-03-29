using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UTC_Clock
{
    class DigitalDisplay : BaseDisplay //konkrete Beobachter
    {
        private DigitalClock myForm = null;
        private Command myCmd;
        private int myTimeZone;
        private int myPosX;
        private int myPosY;

        public DigitalDisplay(Command myCommandObj)
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
            myForm = new DigitalClock(myPosX, myPosY, myTimeZone);
            SingletonClock.Instance.attach(this);
            Console.WriteLine("myTimezone" + myTimeZone);
        }

       
        ~DigitalDisplay()
        {
            this.exit();
        }

        public override void update()
        {
         myForm.myTime = SingletonClock.Instance.GetTime;
         myForm.myTime += TimeSpan.Parse(myTimeZone + ":00:00");
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
