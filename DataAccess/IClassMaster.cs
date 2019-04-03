using System.Data;

namespace DataAccess
{
    public interface IClassMaster
    {
        int ClassMaster_Delete(int classMasterId);
        DataTable ClassMaster_GetAll();
        DataTable ClassMaster_GetById(int classMasterId);
        int ClassMaster_Save(int classMasterId, string classMasterName, string description);
    }
}