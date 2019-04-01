using System.Data;

namespace DataAccess
{
    public interface IRoleAccessLevel
    {
        DataTable RoleAccessLevel_GetByRoleId(int RoleId);
        void RoleAccessLevel_Save(int RoleId, int PermissionId, bool isChecked);
    }
}