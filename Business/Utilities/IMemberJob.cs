using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IMemberJob
    {
        int MemberJob_Delete(int memberAddressId);
        DataTable MemberJob_GetAll(Model.MemberJob memberJob);
        int MemberJob_Save(Model.MemberJob memberJob);
    }
}