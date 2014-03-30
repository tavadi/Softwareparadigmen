using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTC_Clock
{

    public abstract class BaseClock
    {
        #region Observer Pattern
        public List<BaseDisplay> subscriberList = new List<BaseDisplay>();

        //Speichert Subscriber in die Liste
        public void attach(BaseDisplay display)
        {
            subscriberList.Add(display);
        }


        //Löscht Subscriber aus der Liste
        public void detach(BaseDisplay display)
        {
            subscriberList.Remove(display);
        }

        
        public void notifyObservers()
        {
            foreach (BaseDisplay element in subscriberList)
            {
                //Ruft bei jedem Subscriper Update auf
                element.update();
            }
        }
        #endregion


    }
}
