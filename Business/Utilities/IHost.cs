using System.Data;

namespace Business.Utilities
{
    public interface IHost
    {
        int Host_Delete(int hostId);
        DataTable Host_GetAll(Model.Host host);
        int Host_Save(Model.Host host);
    }
}