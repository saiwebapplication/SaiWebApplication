using Autofac;
using Business;
using Business.Utilities;
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebAppSai
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dtUser;
            DataSet dsUserRole;
            string roles = string.Empty;
            int userId = 0;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var login = scope.Resolve<ILogin>();
                using (dtUser = login.GetUserByUserName(txtUserName.Text.Trim(), txtPassword.Text))
                {
                    if (dtUser != null && dtUser.AsEnumerable().Any())
                    {
                        userId = Convert.ToInt32(dtUser.Rows[0]["UserId"].ToString());
                        using (dsUserRole = login.GetUserRolesByUserId(userId))
                        {
                            if (dsUserRole != null && dsUserRole.Tables.Count > 0 && dsUserRole.Tables[0].AsEnumerable().Any())
                            {
                                roles = dsUserRole.Tables[0].Rows[0]["Roles"].ToString();
                            }
                        }

                        SetRoles(userId.ToString(), roles);
                        Business.Context.UserName = string.Format("{0} {1}", dsUserRole.Tables[0].Rows[0]["FirstName"].ToString(), dsUserRole.Tables[0].Rows[0]["LastName"].ToString());
                        Response.Redirect(@"Dashboard.aspx");
                    }
                    else
                    {
                        lblMessage.InnerText = "Invalid username/password";
                    }
                }
            }
        }

        private void SetRoles(string userId, string roles)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                                                       1,
                                                                       userId,
                                                                       DateTime.Now,
                                                                       DateTime.Now.AddHours(2),
                                                                       false,
                                                                       roles, //define roles here
                                                                       "/");
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
            Response.Cookies.Add(cookie);
        }
    }
}