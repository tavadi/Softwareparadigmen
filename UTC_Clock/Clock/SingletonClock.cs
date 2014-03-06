using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UTC_Clock
{
    public class SingletonClock : BaseClock
    {
      private static SingletonClock instance;
      private DateTime myTime;

      private SingletonClock() {
          myTime = DateTime.Now;    //initialisierung mit system zeit
      }

      public DateTime getTime()
      {
          return myTime;
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
