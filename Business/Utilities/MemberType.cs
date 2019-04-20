using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class MemberType : IMemberType
    {
        DataAccess.IMemberType _MemberType;

        public MemberType(DataAccess.IMemberType memberType)
        {
            this._MemberType = memberType;
        }

        public DataTable MemberType_GetAll()
        {
            return _MemberType.MemberType_GetAll();
        }
    }
}
