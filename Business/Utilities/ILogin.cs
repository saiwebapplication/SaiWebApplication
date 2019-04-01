using System.Data;

namespace Business.Utilities
{
    public interface ILogin
    {
        DataTable GetUserByUserName(string userName);
        DataSet GetUserRolesByUserId(int userId);
    }
}