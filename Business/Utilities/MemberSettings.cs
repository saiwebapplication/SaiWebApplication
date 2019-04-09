using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class MemberSettings : IMemberSettings
    {
        DataAccess.IMemberSettings _MemberSettings;

        public MemberSettings(DataAccess.IMemberSettings memberSettings)
        {
            this._MemberSettings = memberSettings;
        }

        public int MemberSettings_Save(Model.MemberSettings memberSettings)
        {
            return _MemberSettings.MemberSettings_Save(memberSettings);
        }

        public DataTable MemberSettings_GetById(Model.MemberSettings memberSettings)
        {
            return _MemberSettings.MemberSettings_GetById(memberSettings);
        }
    }
}
