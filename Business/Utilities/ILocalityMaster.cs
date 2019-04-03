using System.Data;

namespace Business.Utilities
{
    public interface ILocalityMaster
    {
        int LocalityMaster_Delete(int localityMasterId);
        DataTable LocalityMaster_GetAll();
        DataTable LocalityMaster_GetById(int localityMasterId);
        int LocalityMaster_Save(int localityMasterId, string localityMasterName, string description);
    }
}