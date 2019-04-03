using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class EventType : IEventType
    {
        DataAccess.IEventType _EventType;

        public EventType(DataAccess.IEventType eventType)
        {
            this._EventType = eventType;
        }

        public int EventType_Save(int eventTypeId, string eventTypeName)
        {
            return _EventType.EventType_Save(eventTypeId, eventTypeName);

        }

        public DataTable EventType_GetAll()
        {
            return _EventType.EventType_GetAll();
        }

        public DataTable EventType_GetById(int eventTypeId)
        {
            return _EventType.EventType_GetById(eventTypeId);
        }

        public int EventType_Delete(int eventTypeId)
        {
            return _EventType.EventType_Delete(eventTypeId);
        }
    }
}
