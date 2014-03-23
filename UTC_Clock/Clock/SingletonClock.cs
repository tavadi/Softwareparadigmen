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
      private double  AddTime;



      private SingletonClock() {
          myTime = DateTime.Now;    //initialisierung mit system zeit
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

      public void Set()
      {
          Console.WriteLine("set");
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
          foreach(var item in cmd.parameter)
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

    }
}
