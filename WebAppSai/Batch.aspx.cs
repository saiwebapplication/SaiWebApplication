using Autofac;
using Business;
using Business.Utilities;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace WebAppSai
{
    public partial class Batch : System.Web.UI.Page
    {
        public int BatchId
        {
            get { return Convert.ToInt32(ViewState["BatchId"]); }
            set { ViewState["BatchId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadYearList();
                LoadClassList();
                LoadHostList();
                Branch_GetAll();
                ClearControls();
                LoadBatchList();
            }
        }

        private void LoadYearList()
        {
            using (DataTable dtYear = new DataTable())
            {
                dtYear.Columns.Add("Year");
                for (int year = 2019; year <= 2050; year++)
                {
                    DataRow drYear = dtYear.NewRow();
                    drYear["Year"] = year;
                    dtYear.Rows.Add(drYear);
                    dtYear.AcceptChanges();
                }

                ddlYear.DataSource = dtYear;
                ddlYear.DataValueField = "Year";
                ddlYear.DataTextField = "Year";
                ddlYear.DataBind();
            }
            ddlYear.InsertSelect();
        }

        private void LoadHostList()
        {
            DataTable dtHost;
            Model.Host host = new Model.Host() { };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Host = scope.Resolve<IHost>();
                dtHost = Host.Host_GetAll(host);
            }
            if (dtHost != null)
            {
                ddlHost.DataSource = dtHost;
                ddlHost.DataValueField = "HostId";
                ddlHost.DataTextField = "HostName";
                ddlHost.DataBind();
            }
            ddlHost.InsertSelect();
        }

        private void LoadClassList()
        {
            DataTable dtClass;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Class = scope.Resolve<IClassMaster>();
                dtClass = Class.ClassMaster_GetAll();
            }
            if (dtClass != null)
            {
                ddlClass.DataSource = dtClass;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
            }
            ddlClass.InsertSelect();
        }

        private void Branch_GetAll()
        {
            DataTable dtBranch;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Branch = scope.Resolve<IBranch>();
                dtBranch = Branch.Branch_GetAll();
            }
            if (dtBranch != null)
            {
                ddlBranch.DataSource = dtBranch;
                ddlBranch.DataTextField = "BranchName";
                ddlBranch.DataValueField = "BranchId";
                ddlBranch.DataBind();
            }
            ddlBranch.InsertSelect();
        }

        private void ClearControls()
        {
            BatchId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            ddlBranch.SelectedIndex = 0;
            ddlClass.SelectedIndex = 0;
            ddlHost.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            txtBatchName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtStartDate.Text = string.Empty;
        }

        private void LoadBatchList()
        {
            DataTable dtBatch;
            Model.Batch batch = new Model.Batch() { };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Batch = scope.Resolve<IBatch>();
                dtBatch = Batch.Batch_GetAll(batch);
            }
            if (dtBatch != null)
            {
                dgvBatch.DataSource = dtBatch;
                dgvBatch.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int response = 0;
            Model.Batch batch = new Model.Batch()
            {
                BatchId = this.BatchId,
                BatchName = txtBatchName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                ClassId = Convert.ToInt32(ddlClass.SelectedValue),
                BranchId = Convert.ToInt32(ddlBranch.SelectedValue),
                CreatedBy = 1,
                EndDate = Convert.ToDateTime(txtEndDate.Text),
                HostId = Convert.ToInt32(ddlHost.SelectedValue),
                IsCompleted = chkCompleted.Checked,
                StartDate = Convert.ToDateTime(txtStartDate.Text),
                Year = Convert.ToInt32(ddlYear.SelectedValue)
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Batch = scope.Resolve<IBatch>();
                response = Batch.Batch_Save(batch);
            }
            if (response > 0)
            {
                ClearControls();
                LoadBatchList();
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

        protected void dgvBatch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                BatchId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                Batch_GetById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Batch = scope.Resolve<IBatch>();
                    response = Batch.Batch_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadBatchList();
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

        private void Batch_GetById()
        {
            DataTable dtBatch;
            Model.Batch batch = new Model.Batch()
            {
                BatchId = this.BatchId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Batch = scope.Resolve<IBatch>();
                dtBatch = Batch.Batch_GetAll(batch);
            }
            if (dtBatch != null && dtBatch.Rows.Count > 0)
            {
                ddlBranch.SelectedValue = dtBatch.Rows[0]["BranchId"].ToString();
                ddlClass.SelectedValue = dtBatch.Rows[0]["ClassId"].ToString();
                ddlHost.SelectedValue = dtBatch.Rows[0]["HostId"].ToString();
                ddlYear.SelectedValue = dtBatch.Rows[0]["Year"].ToString();
                txtDescription.Text = dtBatch.Rows[0]["Description"].ToString();
                txtBatchName.Text = dtBatch.Rows[0]["BranchName"].ToString();
                txtEndDate.Text = Convert.ToDateTime(dtBatch.Rows[0]["EndDate"].ToString()).ToString("dd MMM yyyy");
                txtStartDate.Text = Convert.ToDateTime(dtBatch.Rows[0]["StartDate"].ToString()).ToString("dd MMM yyyy");
                chkCompleted.Checked = Convert.ToBoolean(dtBatch.Rows[0]["IsCompleted"].ToString());
            }
        }
    }
}