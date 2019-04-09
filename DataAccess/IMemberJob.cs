using System.Data;
using Model;

namespace DataAccess
{
    public interface IMemberJob
    {
        int MemberJob_Delete(int memberJobId);
        DataTable MemberJob_GetAll(Model.MemberJob memberJob);
        int MemberJob_Save(Model.MemberJob memberJob);
    }
}