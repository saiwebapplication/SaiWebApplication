using System.Data;
using Model;

namespace DataAccess
{
    public interface IMember
    {
        int Member_Delete(int memberId);
        DataTable Member_GetAll(Model.Member member);
        int Member_Save(Model.Member member);
    }
}