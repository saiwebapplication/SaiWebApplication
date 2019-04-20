using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Business.Utilities
{
    public class Event : IEvent
    {
        DataAccess.IEvent _Event;
        public Event(DataAccess.IEvent evnt)
        {
            this._Event = evnt;
        }
        public int Event_Delete(int eventId)
        {
            return _Event.Event_Delete(eventId);
        }

        public DataTable Event_GetAll(Model.Event evnt)
        {
            return _Event.Event_GetAll(evnt);
        }

        public int Event_Save(Model.Event evnt)
        {
            return _Event.Event_Save(evnt);
        }
    }
}
