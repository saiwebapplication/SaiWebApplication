using System.Data;

namespace Business.Utilities
{
    public interface IRoleAccessLevel
    {
        DataTable RoleAccessLevel_GetByRoleId(int RoleId);
        void RoleAccessLevel_Save(int RoleId, int PermissionId, bool isChecked);
    }
}