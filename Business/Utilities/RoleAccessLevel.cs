using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class RoleAccessLevel : IRoleAccessLevel
    {
        DataAccess.IRoleAccessLevel _RoleAccessLevel;

        public RoleAccessLevel(DataAccess.IRoleAccessLevel roleAccessLevel)
        {
            this._RoleAccessLevel = roleAccessLevel;
        }

        public void RoleAccessLevel_Save(int RoleId, int PermissionId, bool isChecked)
        {
            _RoleAccessLevel.RoleAccessLevel_Save(RoleId, PermissionId, isChecked);
        }
        public DataTable RoleAccessLevel_GetByRoleId(int RoleId)
        {
            return _RoleAccessLevel.RoleAccessLevel_GetByRoleId(RoleId);
        }
    }
}
