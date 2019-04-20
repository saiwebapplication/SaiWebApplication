using System.Data;
using Model;

namespace DataAccess
{
    public interface IMemberTypeMemberMapping
    {
        int MemberTypeMemberMapping_Delete(int memberTypeMemberMappingId);
        DataTable MemberTypeMemberMapping_GetByMemberId(int memberId);
        int MemberTypeMemberMapping_Save(Model.MemberTypeMemberMapping memberTypeMemberMapping);
    }
}