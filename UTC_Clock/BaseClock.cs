using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{
    public abstract class BaseClock
    {
        private List<BaseDisplay> subscriberList = new List<BaseDisplay>();


        public void attach(BaseDisplay display)
         {
             subscriberList.Add(display);
         }

        public void detach(BaseDisplay display)
         {
             subscriberList.Remove(display);//nicht sicher wie remove funktioniert
         }

         public void notifyObservers()
         {
             foreach (BaseDisplay element in subscriberList)
             {
                 element.update();
             }
         }
    }
}
