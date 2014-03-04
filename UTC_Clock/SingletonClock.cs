using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    public class SingletonClock
    {
      private static SingletonClock instance;

      private SingletonClock() { }

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
