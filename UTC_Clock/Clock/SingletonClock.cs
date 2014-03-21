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
          //myTime = DateTime.Now;    //initialisierung mit system zeit
          aTimer = new System.Timers.Timer(1000);
          aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
          aTimer.Enabled = true;
      }

      private void OnTimedEvent(object source, ElapsedEventArgs e)
      {
          AddTime++; 
          myTime = myTime.Date.AddSeconds(AddTime);
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

    }
}
