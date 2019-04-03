using Autofac;
using Business.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSai.ControlPanel
{
    public partial class LocalityMaster : System.Web.UI.Page
    {
        public int LocalityId
        {
            get { return Convert.ToInt32(ViewState["LocalityId"]); }
            set { ViewState["LocalityId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearControls();
                LoadLocalityList();
            }
        }

        private void ClearControls()
        {
            LocalityId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtLocalityName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void LoadLocalityList()
        {
            DataTable dtLocality;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Locality = scope.Resolve<ILocalityMaster>();
                dtLocality = Locality.LocalityMaster_GetAll();
            }
            if (dtLocality != null)
            {
                dgvLocality.DataSource = dtLocality;
                dgvLocality.DataBind();
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
                var Locality = scope.Resolve<ILocalityMaster>();
                response = Locality.LocalityMaster_Save(LocalityId, txtLocalityName.Text.Trim(), txtDescription.Text.Trim());
            }
            if (response > 0)
            {
                ClearControls();
                LoadLocalityList();
                Message.IsSuccess = true;
                Message.Text = "Saved Successfully";
            }
            else
            {
                Message.IsSuccess = false;
                Message.Text = "Class Name Exists";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadLocalityList();
        }

        protected void dgvLocalityMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                LocalityId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                txtLocalityName.Text = row.Cells[1].Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Locality = scope.Resolve<ILocalityMaster>();
                    response = Locality.LocalityMaster_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadLocalityList();
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