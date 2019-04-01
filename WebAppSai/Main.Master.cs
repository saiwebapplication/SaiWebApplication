using System;

namespace WebAppSai
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUserName.Text = string.Format("Welcome {0}", Business.Context.UserName);
            }
        }
    }
}