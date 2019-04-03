using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class ClassMaster : IClassMaster
    {
        DataAccess.IClassMaster _ClassMaster;

        public ClassMaster(DataAccess.IClassMaster classMaster)
        {
            this._ClassMaster = classMaster;
        }

        public int ClassMaster_Save(int classMasterId, string classMasterName, string description)
        {
            return _ClassMaster.ClassMaster_Save(classMasterId, classMasterName, description);

        }

        public DataTable ClassMaster_GetAll()
        {
            return _ClassMaster.ClassMaster_GetAll();
        }

        public DataTable ClassMaster_GetById(int classMasterId)
        {
            return _ClassMaster.ClassMaster_GetById(classMasterId);
        }

        public int ClassMaster_Delete(int classMasterId)
        {
            return _ClassMaster.ClassMaster_Delete(classMasterId);
        }
    }
}
