using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class LocalityMaster : ILocalityMaster
    {
        DataAccess.ILocalityMaster _LocalityMaster;

        public LocalityMaster(DataAccess.ILocalityMaster LocalityMaster)
        {
            this._LocalityMaster = LocalityMaster;
        }

        public int LocalityMaster_Save(int localityMasterId, string localityMasterName, string description)
        {
            return _LocalityMaster.LocalityMaster_Save(localityMasterId, localityMasterName, description);

        }

        public DataTable LocalityMaster_GetAll()
        {
            return _LocalityMaster.LocalityMaster_GetAll();
        }

        public DataTable LocalityMaster_GetById(int localityMasterId)
        {
            return _LocalityMaster.LocalityMaster_GetById(localityMasterId);
        }

        public int LocalityMaster_Delete(int localityMasterId)
        {
            return _LocalityMaster.LocalityMaster_Delete(localityMasterId);
        }
    }
}
