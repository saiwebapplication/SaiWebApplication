using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class MemberTypeMemberMapping : IMemberTypeMemberMapping
    {
        DataAccess.IMemberTypeMemberMapping _MemberTypeMemberMapping;

        public MemberTypeMemberMapping(DataAccess.IMemberTypeMemberMapping memberTypeMemberMapping)
        {
            this._MemberTypeMemberMapping = memberTypeMemberMapping;
        }

        public int MemberTypeMemberMapping_Save(Model.MemberTypeMemberMapping memberTypeMemberMapping)
        {
            return _MemberTypeMemberMapping.MemberTypeMemberMapping_Save(memberTypeMemberMapping);

        }

        public DataTable MemberTypeMemberMapping_GetByMemberId(int classMasterId)
        {
            return _MemberTypeMemberMapping.MemberTypeMemberMapping_GetByMemberId(classMasterId);
        }

        public int MemberTypeMemberMapping_Delete(int memberTypeMemberMappingId)
        {
            return _MemberTypeMemberMapping.MemberTypeMemberMapping_Delete(memberTypeMemberMappingId);
        }
    }
}
