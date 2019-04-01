using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Login : ILogin
    {
        DataAccess.ILogin _Login;

        public Login(DataAccess.ILogin login)
        {
            this._Login = login; 
        }

        public DataTable GetUserByUserName(string userName) {
            return _Login.GetUserByUserName(userName);
        }
        public DataSet GetUserRolesByUserId(int userId) {
            return _Login.GetUserRolesByUserId(userId);
        }
    }
}
