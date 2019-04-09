using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class MemberAddress : IMemberAddress
    {
        DataAccess.IMemberAddress _MemberAddress;

        public MemberAddress(DataAccess.IMemberAddress memberAddress)
        {
            this._MemberAddress = memberAddress;
        }

        public int MemberAddress_Save(Model.MemberAddress memberAddress)
        {
            return _MemberAddress.MemberAddress_Save(memberAddress);

        }

        public DataTable MemberAddress_GetAll(Model.MemberAddress memberAddress)
        {
            return _MemberAddress.MemberAddress_GetAll(memberAddress);
        }

        public int MemberAddress_Delete(int memberAddressId)
        {
            return _MemberAddress.MemberAddress_Delete(memberAddressId);
        }
    }
}
