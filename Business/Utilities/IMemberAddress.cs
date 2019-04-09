using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IMemberAddress
    {
        DataTable MemberAddress_GetAll(Model.MemberAddress memberAddress);
        int MemberAddress_Save(Model.MemberAddress memberAddress);
        int MemberAddress_Delete(int memberAddressId);
    }
}