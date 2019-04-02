using System.Data;

namespace Business.Utilities
{
    public interface IRole
    {
        int Role_Delete(int roleId);
        DataTable Role_GetAll();
        DataTable Role_GetById(int roleId);
        int Role_Save(int roleId, string roleName);
    }
}