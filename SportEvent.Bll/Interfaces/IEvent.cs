using SportEvent.Bll.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.Bll.Interfaces
{
    public interface IEvent
    {
        string AddEvent(EventModel model);
    }
}
