using System.Data;
using Model;

namespace DataAccess
{
    public interface IMemberAddress
    {
        int MemberAddress_Delete(int memberAddressId);
        DataTable MemberAddress_GetAll(Model.MemberAddress memberAddress);
        int MemberAddress_Save(Model.MemberAddress memberAddress);
    }
}