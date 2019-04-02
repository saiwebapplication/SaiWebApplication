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

                liControlPanel.Visible = HttpContext.Current.User.IsInRole(Model.ControlPanel.CONTROLPANEL);
                liRole.Visible = HttpContext.Current.User.IsInRole(Model.ControlPanel.CONTROLPANEL);
                liRoleAccessLevel.Visible = HttpContext.Current.User.IsInRole(Model.ControlPanel.CONTROLPANEL);
            }
        }
    }
}