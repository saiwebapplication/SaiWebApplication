using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class MemberRelationMapping : IMemberRelationMapping
    {
        DataAccess.IMemberRelationMapping _MemberRelationMapping;

        public MemberRelationMapping(DataAccess.IMemberRelationMapping memberRelationMapping)
        {
            this._MemberRelationMapping = memberRelationMapping;
        }

        public int MemberRelationMapping_Save(Model.MemberRelationMapping memberRelationMapping)
        {
            return _MemberRelationMapping.MemberRelationMapping_Save(memberRelationMapping);

        }

        public DataTable MemberRelationMapping_GetAll(Model.MemberRelationMapping memberRelationMapping)
        {
            return _MemberRelationMapping.MemberRelationMapping_GetAll(memberRelationMapping);
        }

        public int MemberRelationMapping_Delete(int memberRelationMappingId)
        {
            return _MemberRelationMapping.MemberRelationMapping_Delete(memberRelationMappingId);
        }
    }
}
