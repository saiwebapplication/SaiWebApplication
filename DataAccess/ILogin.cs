using System.Data;

namespace DataAccess
{
    public interface ILogin
    {
        DataTable GetUserByUserName(string userName);
        DataSet GetUserRolesByUserId(int userId);
    }
}