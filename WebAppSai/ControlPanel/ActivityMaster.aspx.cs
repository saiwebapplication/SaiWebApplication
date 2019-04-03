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
    public partial class ActivityMaster : System.Web.UI.Page
    {
        public int ActivityMasterId
        {
            get { return Convert.ToInt32(ViewState["ActivityMasterId"]); }
            set { ViewState["ActivityMasterId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearControls();
                LoadActivityMasterList();
            }
        }

        private void ClearControls()
        {
            ActivityMasterId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtActivityName.Text = "";
        }

        private void LoadActivityMasterList()
        {
            DataTable dtActivityMaster;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var ActivityMaster = scope.Resolve<IActivityMaster>();
                dtActivityMaster = ActivityMaster.ActivityMaster_GetAll();
            }
            if (dtActivityMaster != null)
            {
                dgvActivity.DataSource = dtActivityMaster;
                dgvActivity.DataBind();
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
                var ActivityMaster = scope.Resolve<IActivityMaster>();
                response = ActivityMaster.ActivityMaster_Save(ActivityMasterId, txtActivityName.Text.Trim());
            }
            if (response > 0)
            {
                ClearControls();
                LoadActivityMasterList();
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
            LoadActivityMasterList();
        }

        protected void dgvActivity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                ActivityMasterId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                txtActivityName.Text = row.Cells[1].Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var ActivityMaster = scope.Resolve<IActivityMaster>();
                    response = ActivityMaster.ActivityMaster_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadActivityMasterList();
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