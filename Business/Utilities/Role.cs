using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Role : IRole
    {
        DataAccess.IRole _Role;

        public Role(DataAccess.IRole role)
        {
            this._Role = role;
        }

        public int Role_Save(int roleId, string roleName)
        {
            return _Role.Role_Save(roleId, roleName);

        }

        public DataTable Role_GetAll()
        {
            return _Role.Role_GetAll();
        }

        public DataTable Role_GetById(int roleId)
        {
            return _Role.Role_GetById(roleId);
        }

        public int Role_Delete(int roleId)
        {
            return _Role.Role_Delete(roleId);
        }
    }
}
