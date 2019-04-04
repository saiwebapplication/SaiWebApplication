using Autofac;
using Business.Utilities;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace WebAppSai.ControlPanel
{
    public partial class EventType : System.Web.UI.Page
    {
        public int EventTypeId
        {
            get { return Convert.ToInt32(ViewState["EventTypeId"]); }
            set { ViewState["EventTypeId"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearControls();
                LoadEventTypeList();
            }
        }

        private void ClearControls()
        {
            EventTypeId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtEventTypeName.Text = "";
        }

        private void LoadEventTypeList()
        {
            DataTable dtEventType;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var EventType = scope.Resolve<IEventType>();
                dtEventType = EventType.EventType_GetAll();
            }
            if (dtEventType != null)
            {
                dgvEventType.DataSource = dtEventType;
                dgvEventType.DataBind();
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
                var EventType = scope.Resolve<IEventType>();
                response = EventType.EventType_Save(EventTypeId, txtEventTypeName.Text.Trim());
            }
            if (response > 0)
            {
                ClearControls();
                LoadEventTypeList();
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
            LoadEventTypeList();
        }

        protected void dgvEventType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                EventTypeId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                txtEventTypeName.Text = row.Cells[1].Text;
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var EventType = scope.Resolve<IEventType>();
                    response = EventType.EventType_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadEventTypeList();
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