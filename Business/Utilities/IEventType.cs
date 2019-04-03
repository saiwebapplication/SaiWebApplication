using System.Data;

namespace Business.Utilities
{
    public interface IEventType
    {
        int EventType_Delete(int eventTypeId);
        DataTable EventType_GetAll();
        DataTable EventType_GetById(int eventTypeId);
        int EventType_Save(int eventTypeId, string eventTypeName);
    }
}