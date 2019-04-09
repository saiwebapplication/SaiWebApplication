using Model;
using System.Data;

namespace Business.Utilities
{
    public interface IMemberSettings
    {
        int MemberSettings_Save(Model.MemberSettings memberSettings);
        DataTable MemberSettings_GetById(Model.MemberSettings memberSettings);
    }
}