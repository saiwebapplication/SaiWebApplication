using System.Data;

namespace Business.Utilities
{
    public interface ILogin
    {
        DataTable GetUserByUserName(string userName, string password);
        DataSet GetUserRolesByUserId(int userId);
    }
}