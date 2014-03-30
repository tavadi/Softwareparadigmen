using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers; //ElapsedEventArgs
using System.Windows.Forms;


namespace UTC_Clock
{
    //konkrete subjekt
    public class SingletonClock : BaseClock
    {
        private static SingletonClock instance;
        private DateTime myTime;
        private static System.Timers.Timer aTimer;
        private List<TimeSpan> CmdSetHistory { get; set; }

        #region Singleton Pattern

        private SingletonClock()
        {
            //initialisierung mit system zeit
            myTime = DateTime.Now;
            CmdSetHistory = new List<TimeSpan>();
            //Jede Sekunde 
            aTimer = new System.Timers.Timer(1000);
            //Springt aTimer an
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
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

        #endregion


        #region ClockLogic
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            myTime += TimeSpan.Parse("00:00:01"); //fügt jede Sekunde eine Sekunde hinzu ^^
            SingletonClock.Instance.notifyObservers();
        }

        #endregion


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


        public void Decrease(Command cmd) // dec {–h} {–m} {–s}
        {
            foreach (var item in cmd.parameter)
            {
                switch (item)
                {
                    case "-h":
                        //Fügt eine Stunde hinzu
                        myTime -= TimeSpan.Parse("01:00:00");
                        break;
                    case "-m":
                        //Fügt eine Mnute hinzu
                        myTime -= TimeSpan.Parse("00:01:00");
                        break;
                    case "-s":
                        //Fügt eine Sekunde hinzu
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
                        //Zieht eine Stunde Ab
                        myTime += TimeSpan.Parse("01:00:00");
                        break;
                    case "-m":
                        //Zieht eine Minute Ab
                        myTime += TimeSpan.Parse("00:01:00");
                        break;
                    case "-s":
                        //Zieht eine Sekunde Ab
                        myTime += TimeSpan.Parse("00:00:01");
                        break;
                    default:
                        break;
                }
            }
        }


        public void Set(Command cmd)
        {
            //Zwischenspeicher zum ausrechnen der Differenz
            DateTime initialtime = myTime;
            try
            {
                //Paramter immer im 2er Paar (-h 20 -m 30)
                if (cmd.parameter.Count % 2 == 0)
                {
                    for (int i = 0; i < cmd.parameter.Count; i++)
                    {
                        switch (cmd.parameter[i])
                        {
                            case "-h":
                                //Console.WriteLine("-h");
                                int hour = Convert.ToInt32(cmd.parameter[i + 1]);
                                myTime = new DateTime(myTime.Year, myTime.Month, myTime.Day, hour, myTime.Minute, myTime.Second);
                                //Console.WriteLine(hour);
                                break;
                            case "-m":
                                //Console.WriteLine("-m" + cmd.parameter[i + 1]);
                                int minute = Convert.ToInt32(cmd.parameter[i + 1]);
                                myTime = new DateTime(myTime.Year, myTime.Month, myTime.Day, myTime.Hour, minute, myTime.Second);
                                break;
                            case "-s":
                                //Console.WriteLine("-s" + cmd.parameter[i + 1]);
                                int second = Convert.ToInt32(cmd.parameter[i + 1]);
                                myTime = new DateTime(myTime.Year, myTime.Month, myTime.Day, myTime.Hour, myTime.Minute, second);
                                break;
                            default:
                                break;
                        }
                    }
                    TimeSpan difference = new TimeSpan();
                    //Speichert die Differenz
                    difference = myTime.Subtract(initialtime);
                    //In eine Liste
                    CmdSetHistory.Add(difference);

                }
                else
                {
                    MessageBox.Show("Paramter only in pair of twos! <set -h 20>");
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show("Wrong Input Format! Type Help!");
                Console.WriteLine(e);
            }
        }


        public void undoSet()
        {
            try
            {
                //holt sich die letzte Zeitdifferenz
                TimeSpan difference = CmdSetHistory[0];
                //Console.WriteLine("timespan: " + difference);
                //zieht sie davon ab
                myTime -= difference;
                //und löscht die Differenz aus der liste
                CmdSetHistory.Remove(difference);
            }
            catch (Exception e)
            {
                MessageBox.Show("I can not undo this set command, maybe wrong parameters!");
                Console.WriteLine(e);
            }
        }

    }

}
