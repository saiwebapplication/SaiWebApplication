using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class MemberJob : IMemberJob
    {
        DataAccess.IMemberJob _MemberJob;

        public MemberJob(DataAccess.IMemberJob memberJob)
        {
            this._MemberJob = memberJob;
        }

        public int MemberJob_Save(Model.MemberJob memberJob)
        {
            return _MemberJob.MemberJob_Save(memberJob);

        }

        public DataTable MemberJob_GetAll(Model.MemberJob memberJob)
        {
            return _MemberJob.MemberJob_GetAll(memberJob);
        }

        public int MemberJob_Delete(int memberAddressId)
        {
            return _MemberJob.MemberJob_Delete(memberAddressId);
        }
    }
}
