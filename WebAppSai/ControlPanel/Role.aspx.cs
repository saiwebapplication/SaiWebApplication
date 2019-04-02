using Autofac;
using Business.Utilities;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace WebAppSai.ControlPanel
{
    public partial class Role : System.Web.UI.Page
    {
        public int RoleId
        {
            get { return Convert.ToInt32(ViewState["RoleId"]); }
            set { ViewState["RoleId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearControls();
                LoadRoleList();
            }
        }

        private void ClearControls()
        {
            RoleId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtRole.Text = "";
        }

        private void LoadRoleList()
        {
            DataTable dtRole;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var role = scope.Resolve<IRole>();
                dtRole = role.Role_GetAll();
            }
            if (dtRole != null)
            {
                dgvRoleMaster.DataSource = dtRole;
                dgvRoleMaster.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int response = 0;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var role = scope.Resolve<IRole>();
                response = role.Role_Save(RoleId, txtRole.Text.Trim());
            }
            if (response > 0)
            {
                ClearControls();
                LoadRoleList();
                Message.IsSuccess = true;
                Message.Text = "Saved Successfully";
            }
            else
            {
                Message.IsSuccess = false;
                Message.Text = "Role Name Exists";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRoleList();
        }

        protected void dgvRoleMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                RoleId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                txtRole.Text = row.Cells[1].Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var role = scope.Resolve<IRole>();
                    response = role.Role_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadRoleList();
                    Message.IsSuccess = true;
                    Message.Text = "Deleted Successfully";
                }
                else
                {
                    Message.IsSuccess = false;
                    Message.Text = "Data Dependency Exists";
                }
            }
        }
    }
}