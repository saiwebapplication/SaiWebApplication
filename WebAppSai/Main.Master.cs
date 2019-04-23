using System;
using System.Web;

namespace WebAppSai
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/MainLogout.aspx");

            if (!IsPostBack)
            {
                lblUserName.Text = string.Format("Welcome {0}", Business.Context.UserName);

                liControlPanel.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.CONTROL_PANEL);
                liRole.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.ROLE);
                liRoleAccessLevel.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.ROLE_ACCESS_LEVEL);
                liActivityMaster.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.ACTIVITY_MASTER);
                liClassMaster.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.CLASS_MASTER);
                liEventType.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.EVENT_TYPE);
                liLocalityMaster.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.LOCALITY_MASTER);
                liMembers.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.MEMBERS);
                liHost.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.HOST);
                liBatch.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.BATCH);
                liBatchReport.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.BATCH_REPORT);
                liEventReport.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.EVENT_REPORT);
                liHostReport.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.HOST_REPORT);
                liMemberReport.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.MEMBER_REPORT);
                liReport.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.REPORT);
                liEvent.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.EVENT);
                liEnrolment.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.ENROLMENT);
                liAttendance.Visible = HttpContext.Current.User.IsInRole(Model.SecureObject.ATTENDANCE);
            }
        }
    }
}