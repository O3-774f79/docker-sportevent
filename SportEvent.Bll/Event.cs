using SportEvent.Bll.Interfaces;
using SportEvent.Bll.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.Bll
{
    public class Event : IEvent
    {
        public string AddEvent(EventModel model)
        {
            return $"Add the {model.EventName} is complete.";
        }
    }
}
