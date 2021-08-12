using System;
using System.Collections.Generic;
using System.Text;

namespace BoBo2D_Eyal_Gal
{
    public class UIHandler:IStartable
    {
        public UIHandler()
        {
            SubscriptionManager.AddSubscriber<IStartable>(this);
        }
        public void Start()
        {

        }
        void CreateHealthBar()
        {

        }
    }
}
