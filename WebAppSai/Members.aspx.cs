using Autofac;
using Business.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSai
{
    public partial class Members : System.Web.UI.Page
    {
        private void Member_GetAll()
        {
            DataTable dtMember;
            Model.Member member = new Model.Member() {
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Member = scope.Resolve<IMember>();
                dtMember = Member.Member_GetAll(member);
            }
            if (dtMember != null)
            {
                dgvMember.DataSource = dtMember;
                dgvMember.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Member_GetAll();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void dgvMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}