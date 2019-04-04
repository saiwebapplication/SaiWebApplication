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
    public partial class ClassMaster : System.Web.UI.Page
    {
        public int ClassId
        {
            get { return Convert.ToInt32(ViewState["ClassId"]); }
            set { ViewState["ClassId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearControls();
                LoadClassList();
            }
        }

        private void ClearControls()
        {
            ClassId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtClassName.Text = string.Empty;
            txtDescription.Text = string.Empty;
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
                dgvClass.DataSource = dtClass;
                dgvClass.DataBind();
            }
        }

        private void ClassMaster_GetById()
        {
            DataTable dtClass;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Class = scope.Resolve<IClassMaster>();
                dtClass = Class.ClassMaster_GetById(ClassId);
            }
            if (dtClass != null && dtClass.Rows.Count>0)
            {
                txtClassName.Text = dtClass.Rows[0]["ClassName"].ToString();
                txtDescription.Text = dtClass.Rows[0]["Description"].ToString();
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
                var Class = scope.Resolve<IClassMaster>();
                response = Class.ClassMaster_Save(ClassId, txtClassName.Text.Trim(), txtDescription.Text.Trim());
            }
            if (response > 0)
            {
                ClearControls();
                LoadClassList();
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
            LoadClassList();
        }

        protected void dgvClassMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                ClassId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                ClassMaster_GetById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Class = scope.Resolve<IClassMaster>();
                    response = Class.ClassMaster_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadClassList();
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