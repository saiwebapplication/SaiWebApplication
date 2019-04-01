using System.Data;

namespace DataAccess
{
    public interface ILogin
    {
        DataTable GetUserByUserName(string userName, string password);
        DataSet GetUserRolesByUserId(int userId);
    }
}