using System.Data;
using Model;

namespace DataAccess
{
    public interface IHost
    {
        DataTable Host_GetAll(Model.Host host);
        int Host_Save(Model.Host host);
        int Host_Delete(int hostId);
    }
}