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
    public partial class Host : System.Web.UI.Page
    {
        public int HostId
        {
            get { return Convert.ToInt32(ViewState["HostId"]); }
            set { ViewState["HostId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearControls();
                LoadHostList();
            }
        }

        private void ClearControls()
        {
            HostId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtContactNo.Text = "";
            txtDescription.Text = string.Empty;
            txtHostName.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtMapLocation.Text = string.Empty;
        }

        private void LoadHostList()
        {
            DataTable dtHost;
            Model.Host host = new Model.Host() {};
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Host = scope.Resolve<IHost>();
                dtHost = Host.Host_GetAll(host);
            }
            if (dtHost != null)
            {
                dgvHost.DataSource = dtHost;
                dgvHost.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int response = 0;
            Model.Host host = new Model.Host() {
                HostId = this.HostId,
                ContactNos=txtContactNo.Text.Trim(),
                Description=txtDescription.Text.Trim(),
                HostName = txtHostName.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                Maplocation = txtMapLocation.Text.Trim()
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Host = scope.Resolve<IHost>();
                response = Host.Host_Save(host);
            }
            if (response > 0)
            {
                ClearControls();
                LoadHostList();
                Message.IsSuccess = true;
                Message.Text = "Saved Successfully";
            }
            else
            {
                Message.IsSuccess = false;
                Message.Text = "Host Name Exists";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        protected void dgvHost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                HostId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                Host_GetById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Host = scope.Resolve<IHost>();
                    response = Host.Host_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadHostList();
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

        private void Host_GetById()
        {
            DataTable dtHost;
            Model.Host host = new Model.Host()
            {
                HostId = this.HostId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Host = scope.Resolve<IHost>();
                dtHost = Host.Host_GetAll(host);
            }
            if (dtHost != null && dtHost.Rows.Count > 0)
            {
                txtContactNo.Text = dtHost.Rows[0]["ContactNos"].ToString();
                txtDescription.Text = dtHost.Rows[0]["Description"].ToString();
                txtHostName.Text = dtHost.Rows[0]["HostName"].ToString();
                txtLocation.Text = dtHost.Rows[0]["Location"].ToString();
                txtMapLocation.Text = dtHost.Rows[0]["MapLocation"].ToString();
            }
        }
    }
}