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
            }
        }
    }
}