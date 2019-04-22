using Autofac;
using Business;
using Business.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSai
{
    public partial class Event : System.Web.UI.Page
    {
        public int EventId
        {
            get { return Convert.ToInt32(ViewState["EventId"]); }
            set { ViewState["EventId"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                EventType_GetAll();
                Branch_GetAll();
                Event_GetAll();
            }

        }
        private void EventType_GetAll()
        {
            DataTable dtEventType;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var EventType = scope.Resolve<IEventType>();
                dtEventType = EventType.EventType_GetAll();
            }
            if (dtEventType != null)
            {
                ddlEventType.DataSource = dtEventType;
                ddlEventType.DataTextField = "EventTypeName";
                ddlEventType.DataValueField = "EventTypeId";
                ddlEventType.DataBind();
            }
            ddlEventType.InsertSelect();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Event evnt = new Model.Event()
                {
                    EventId = this.EventId,
                    EventName = txtEventName.Text.Trim(),
                    EventTypeId = int.Parse(ddlEventType.SelectedValue),
                    BranchId = int.Parse(ddlBranch.SelectedValue),
                    CreatedBy = int.Parse(HttpContext.Current.User.Identity.Name),
                    EventStartDate = (string.IsNullOrEmpty(txtEventStartDate.Text.Trim())) ? DateTime.MinValue : Convert.ToDateTime(txtEventStartDate.Text),
                    EventEndDate = (string.IsNullOrEmpty(txtEventEndDate.Text.Trim())) ? DateTime.MinValue : Convert.ToDateTime(txtEventEndDate.Text),
                    Description = txtDescription.Text.Trim(),
                    Venue = txtVenue.Text.Trim(),
                   
                };
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Event = scope.Resolve<IEvent>();
                    EventId = Event.Event_Save(evnt);
                }
                if (EventId > 0)
                {

                    ClearEventControls();
                    Event_GetAll();
                    Message.IsSuccess = true;
                    Message.Text = "Saved Successfully";
                    Thread.Sleep(1000);
                    OpenPopup();
                }
                else
                {
                    Message.IsSuccess = false;
                    Message.Text = "Not saved.";
                }
            }
            catch (Exception ex)
            {
                Message.IsSuccess = false;
                Message.Text = ex.Message;
            }
        }
        private void OpenPopup()
        {
            
            ModalPopupExtender1.Show();
        }
        private void ClearEventControls()
        {
            EventId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtEventName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtVenue.Text = string.Empty;
            txtEventStartDate.Text = string.Empty;
            txtEventEndDate.Text = string.Empty;
            ddlBranch.SelectedIndex = 0;
            ddlEventType.SelectedIndex = 0;
        }
        private void Event_GetAll()
        {
            DataTable dtEvent;
            Model.Event evnt = new Model.Event()
            {
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Event = scope.Resolve<IEvent>();
                dtEvent = Event.Event_GetAll(evnt);
            }

            dgvEvent.DataSource = dtEvent;
            dgvEvent.DataBind();
        }

        protected void dgvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Ed")
                {
                    EventId = Convert.ToInt32(e.CommandArgument.ToString());
                    Event_GetById();
                    btnSave.Text = "Update";
                }
                else if (e.CommandName == "Del")
                {
                    int response = 0;
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var Event = scope.Resolve<IEvent>();
                        response = Event.Event_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    }
                    if (response > 0)
                    {
                        Event_GetAll();
                        Message.IsSuccess = true;
                        Message.Text = "Deleted Successfully";
                    }
                    else
                    {
                        Message.IsSuccess = false;
                        Message.Text = "Data Dependency Exists";
                    }
                }
                //else if (e.CommandName == "Settings")
                //{
                //    MemberId = Convert.ToInt32(e.CommandArgument.ToString());
                //    LocalityMaster_GetAll();
                //    MemberAddress_GetAll();
                //    OpenPopup();
                //}
            }
            catch (Exception ex)
            {
                Message.IsSuccess = false;
                Message.Text = ex.Message;
            }
        }

        private void Event_GetById()
        {
            DataTable dtEvent;
            Model.Event evnt = new Model.Event()
            {
                EventId = this.EventId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Event = scope.Resolve<IEvent>();
                dtEvent = Event.Event_GetAll(evnt);
            }
            if (dtEvent != null && dtEvent.Rows.Count > 0)
            {
                txtEventName.Text = dtEvent.Rows[0]["EventName"].ToString();
                txtDescription.Text = dtEvent.Rows[0]["Description"].ToString();
                txtEventStartDate.Text = (dtEvent.Rows[0]["EventStartDate"] == DBNull.Value) ? "" : Convert.ToDateTime(dtEvent.Rows[0]["EventStartDate"].ToString()).ToString("dd MMM yyyy");
                txtEventEndDate.Text = (dtEvent.Rows[0]["EventEndDate"] == DBNull.Value) ? "" : Convert.ToDateTime(dtEvent.Rows[0]["EventEndDate"].ToString()).ToString("dd MMM yyyy");
                txtVenue.Text = dtEvent.Rows[0]["Venue"].ToString();
                ddlBranch.SelectedValue = (dtEvent.Rows[0]["BranchId"] == DBNull.Value) ? "0" : dtEvent.Rows[0]["BranchId"].ToString();
                ddlEventType.SelectedValue = dtEvent.Rows[0]["EventTypeId"].ToString();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearEventControls();
        }
    }
}