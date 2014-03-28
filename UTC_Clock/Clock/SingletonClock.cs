using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers; //ElapsedEventArgs


namespace UTC_Clock
{

    public class SingletonClock : BaseClock //konkrete subjekt
    {
        private static SingletonClock instance;
        private DateTime myTime;
        private static System.Timers.Timer aTimer;
        private List<TimeSpan> CmdSetHistory { get; set; }

        private SingletonClock()
        {
            myTime = DateTime.Now;    //initialisierung mit system zeit
            CmdSetHistory = new List<TimeSpan>();
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // Console.WriteLine("mytime update: " + myTime);
            myTime += TimeSpan.Parse("00:00:01"); //fügt jede sekunde eine sekunde hinzu
            // Console.WriteLine("ontimedeven: " + myTime);
            SingletonClock.Instance.notifyObservers();
        }



        public DateTime GetTime
        {
            get
            {
                return myTime;
            }

            set
            {
                myTime = value;
            }
        }


        public static SingletonClock Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonClock();
                }
                return instance;
            }
        }

        public void Decrease(Command cmd) // dec {–h} {–m} {–s}
        {
            /* foreach (KeyValuePair<string,string> pair in cmd.parameter)
             {
                 Console.WriteLine(" Key : " + pair.Key + " Value : " + pair.Value);
             }*/
            foreach (var item in cmd.parameter)
            {
                switch (item)
                {
                    case "-h":
                        myTime -= TimeSpan.Parse("01:00:00");
                        break;
                    case "-m":
                        myTime -= TimeSpan.Parse("00:01:00");
                        break;
                    case "-s":
                        myTime -= TimeSpan.Parse("00:00:01");
                        break;
                    default:
                        break;
                }

            }
        }

        public void Increase(Command cmd) // dec {–h} {–m} {–s}
        {

            foreach (var item in cmd.parameter)
            {
                switch (item)
                {
                    case "-h":
                        myTime += TimeSpan.Parse("01:00:00");
                        break;
                    case "-m":
                        myTime += TimeSpan.Parse("00:01:00");
                        break;
                    case "-s":
                        myTime += TimeSpan.Parse("00:00:01");
                        break;
                    default:
                        break;
                }

            }
        }


        public void Set(Command cmd)
        {
            DateTime initialtime = myTime;
            try
            {
                if (cmd.parameter.Count % 2 == 0)
                {

                    for (int i = 0; i < cmd.parameter.Count; i++)
                    {
                        switch (cmd.parameter[i])
                        {
                            case "-h":
                                Console.WriteLine("-h");
                                int hour = Convert.ToInt32(cmd.parameter[i + 1]);
                                myTime = new DateTime(myTime.Year, myTime.Month, myTime.Day, hour, myTime.Minute, myTime.Second);
                                Console.WriteLine(hour);
                                break;
                            case "-m":
                                Console.WriteLine("-m" + cmd.parameter[i + 1]);
                                int minute = Convert.ToInt32(cmd.parameter[i + 1]);
                                myTime = new DateTime(myTime.Year, myTime.Month, myTime.Day, myTime.Hour, minute, myTime.Second);
                                break;
                            case "-s":
                                Console.WriteLine("-s" + cmd.parameter[i + 1]);
                                int second = Convert.ToInt32(cmd.parameter[i + 1]);
                                myTime = new DateTime(myTime.Year, myTime.Month, myTime.Day, myTime.Hour, myTime.Minute, second);
                                break;
                            default:
                                break;
                        }
                    }
                    TimeSpan difference = new TimeSpan();
                    difference = myTime.Subtract(initialtime);
                    CmdSetHistory.Add(difference);

                }
                else
                {
                    //error wrong paramter 
                    Console.WriteLine("wrong poaramter");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("wrong input format");
            }
        }

        public void undoSet()
        {
            TimeSpan difference = CmdSetHistory[0];
            Console.WriteLine("timespan: " + difference);
            myTime -= difference;
            CmdSetHistory.Remove(difference);
        }




    }

}
