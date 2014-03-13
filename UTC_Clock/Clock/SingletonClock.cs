using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UTC_Clock
{
    public class SingletonClock : BaseClock //konkrete subjekt
    {
      private static SingletonClock instance;
      private DateTime myTime;

      private SingletonClock() {
          myTime = DateTime.Now;    //initialisierung mit system zeit
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

        private 
    }
}
