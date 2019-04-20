using System.Data;
using Model;

namespace Business.Utilities
{
    public interface IMemberTypeMemberMapping
    {
        int MemberTypeMemberMapping_Delete(int memberTypeMemberMappingId);
        DataTable MemberTypeMemberMapping_GetByMemberId(int classMasterId);
        int MemberTypeMemberMapping_Save(Model.MemberTypeMemberMapping memberTypeMemberMapping);
    }
}