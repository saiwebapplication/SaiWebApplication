using System.Data;

namespace Business.Utilities
{
    public interface IActivityMaster
    {
        int ActivityMaster_Delete(int activityMasterId);
        DataTable ActivityMaster_GetAll();
        DataTable ActivityMaster_GetById(int activityMasterId);
        int ActivityMaster_Save(int activityMasterId, string activityMasterName);
    }
}