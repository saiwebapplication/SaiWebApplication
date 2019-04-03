using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class ActivityMaster : IActivityMaster
    {
        DataAccess.IActivityMaster _ActivityMaster;

        public ActivityMaster(DataAccess.IActivityMaster activityMaster)
        {
            this._ActivityMaster = activityMaster;
        }

        public int ActivityMaster_Save(int activityMasterId, string activityMasterName)
        {
            return _ActivityMaster.ActivityMaster_Save(activityMasterId, activityMasterName);

        }

        public DataTable ActivityMaster_GetAll()
        {
            return _ActivityMaster.ActivityMaster_GetAll();
        }

        public DataTable ActivityMaster_GetById(int activityMasterId)
        {
            return _ActivityMaster.ActivityMaster_GetById(activityMasterId);
        }

        public int ActivityMaster_Delete(int activityMasterId)
        {
            return _ActivityMaster.ActivityMaster_Delete(activityMasterId);
        }
    }
}
