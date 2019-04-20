using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public interface IEvent
    {
        int Event_Save(Model.Event evnt);
        int Event_Delete(int eventId);
        DataTable Event_GetAll(Model.Event evnt);
    }
}
