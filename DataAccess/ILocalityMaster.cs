using System.Data;

namespace DataAccess
{
    public interface ILocalityMaster
    {
        int LocalityMaster_Delete(int localityMasterId);
        DataTable LocalityMaster_GetAll();
        DataTable LocalityMaster_GetById(int LocalityMasterId);
        int LocalityMaster_Save(int localityMasterId, string localityMasterName, string description);
    }
}