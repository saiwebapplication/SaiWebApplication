using Autofac;
using Business;
using Business.Utilities;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAppSai
{
    public partial class Attendance : System.Web.UI.Page
    {
        public int AttendanceTypeId
        {
            get { return Convert.ToInt32(ViewState["AttendanceTypeId"]); }
            set { ViewState["AttendanceTypeId"] = value; }
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

                ddlClassEvent.DataSource = dtClass;
                ddlClassEvent.DataTextField = "ClassName";
                ddlClassEvent.DataValueField = "ClassId";
                ddlClassEvent.DataBind();
            }
            ddlClass.InsertSelect();

            ddlClassEvent.InsertSelect();
        }
        private void LoadBatchList()
        {
            DataTable dtBatch;
            Model.Batch batch = new Model.Batch()
            {
                ClassId = Convert.ToInt32(ddlClass.SelectedValue)
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Batch = scope.Resolve<IBatch>();
                dtBatch = Batch.Batch_GetAll(batch);
            }
            if (dtBatch != null)
            {
                ddlBatch.DataSource = dtBatch;
                ddlBatch.DataTextField = "BatchName";
                ddlBatch.DataValueField = "BatchId";
                ddlBatch.DataBind();

                ddlBatchEvent.DataSource = dtBatch;
                ddlBatchEvent.DataTextField = "BatchName";
                ddlBatchEvent.DataValueField = "BatchId";
                ddlBatchEvent.DataBind();
            }
            ddlBatchEvent.InsertSelect();

            ddlBatch.InsertSelect();
        }

        private void LoadEvents()
        {
            DataTable dtEvent;
            Model.Event evnt = new Model.Event() { };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Event = scope.Resolve<IEvent>();
                dtEvent = Event.Event_GetAll(evnt);
            }
            if (dtEvent != null)
            {
                ddlEvent.DataSource = dtEvent;
                ddlEvent.DataTextField = "EventName";
                ddlEvent.DataValueField = "EventId";
                ddlEvent.DataBind();
            }
            ddlEvent.InsertSelect();
        }
        private void ClearStudentControls()
        {
            AttendanceTypeId = 1;
            Message.Text = string.Empty;
            ddlClass.SelectedIndex = 0;
            ddlBatch.SelectedIndex = 0;
            txtEnrolmentNo.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            TabContainer2.ActiveTabIndex = 0;
            dgvStudentAttendance.DataBind();
        }
        private void LoadAttendanceList()
        {
            DataTable dtAttendance;
            Model.Attendance attendance = new Model.Attendance()
            {
                AttendanceTypeId = this.AttendanceTypeId,
                EnrolmentNo = txtEnrolmentNo.Text.Trim(),
                CreatedBy = 1,
                EventId = Convert.ToInt32(ddlBatch.SelectedValue),
                MemberId = (string.IsNullOrEmpty(hfStudentId.Value) ? 0 : Convert.ToInt32(hfStudentId.Value)),
                AttendanceDate = Convert.ToDateTime(txtAttendanceDate.Text)
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Attendance = scope.Resolve<IAttendance>();
                dtAttendance = Attendance.Attendance_GetAll(attendance);
            }
            if (dtAttendance != null)
            {
                dgvStudentAttendance.DataSource = dtAttendance;
                dgvStudentAttendance.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfCurrentDateTime.Value = DateTime.Now.ToString("dd MMM yyyy hh:mm tt");
                txtAttendanceDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                AttendanceTypeId = 1;
                LoadClassList();
                LoadBatchList();
                LoadEvents();
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBatchList();
        }

        protected void ddlClassEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBatchList();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAttendanceList();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearStudentControls();
        }

        protected void btnSearchEvent_Click(object sender, EventArgs e)
        {
            LoadAttendanceList();
        }

        protected void btnClearEvent_Click(object sender, EventArgs e)
        {
            ClearStudentControls();
        }

        protected void TabContainer2_ActiveTabChanged(object sender, EventArgs e)
        {
            if (TabContainer2.ActiveTabIndex == 0)
            {
                AttendanceTypeId = 1;
            }
            else
            {
                AttendanceTypeId = 2;
            }
        }

        protected void chkAttendance_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = (CheckBox)sender;
                GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
                string startDateTime = ((HtmlInputText)gridViewRow.FindControl("txtStartDateTime")).Value;

                int memberId = 0, AttendanceId = 0;
                memberId = int.Parse(dgvStudentAttendance.DataKeys[gridViewRow.RowIndex].Values[0].ToString());
                if (checkBox.Checked)
                {
                    AttendanceId = AttendanceInSave(startDateTime, memberId);
                    checkBox.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Message.IsSuccess = false;
                Message.Text = ex.Message;
            }
        }

        private int AttendanceInSave(string startDateTime, int memberId)
        {
            int AttendanceId;
            Model.Attendance attendance = new Model.Attendance()
            {
                AttendanceTypeId = this.AttendanceTypeId,
                EventId = Convert.ToInt32(ddlBatch.SelectedValue),
                MemberId = memberId,
                InDateTime = Convert.ToDateTime(startDateTime),
                CreatedBy = 1,
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Attendance = scope.Resolve<IAttendance>();
                AttendanceId = Attendance.Attendance_Save(attendance);
            }
            if (AttendanceId > 0)
            {
                Message.IsSuccess = true;
                Message.Text = "Saved Successfully";
            }
            else
            {
                Message.IsSuccess = false;
                Message.Text = "Not saved.";
            }

            return AttendanceId;
        }

        protected void dgvStudentAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkAttendance = (CheckBox)e.Row.FindControl("chkAttendance");
                    chkAttendance.Checked = (((DataTable)dgvStudentAttendance.DataSource).Rows[e.Row.RowIndex]["AttendanceId"] != DBNull.Value) ?
                        true : false;
                    chkAttendance.Enabled = !chkAttendance.Checked;

                    CheckBox chkAttendanceOut = (CheckBox)e.Row.FindControl("chkAttendanceOut");
                    chkAttendanceOut.Checked = (((DataTable)dgvStudentAttendance.DataSource).Rows[e.Row.RowIndex]["OutDateTime"] != DBNull.Value) ?
                        true : false;
                    chkAttendanceOut.Enabled = !chkAttendanceOut.Checked;
                }
            }
            catch (Exception ex)
            {
                Message.IsSuccess = false;
                Message.Text = ex.Message;
            }
        }

        protected void chkAttendanceOut_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = (CheckBox)sender;
                GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
                string endDateTime = ((HtmlInputText)gridViewRow.FindControl("txtEndDateTime")).Value;
                if (dgvStudentAttendance.DataKeys[gridViewRow.RowIndex].Values[1] == DBNull.Value)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mmsg", "alert('Activity cancelled, please try again.');", true);
                    Response.Redirect(Request.RawUrl);
                }
                int attendanceId = 0;
                attendanceId = int.Parse(dgvStudentAttendance.DataKeys[gridViewRow.RowIndex].Values[1].ToString());
                if (checkBox.Checked)
                {
                    attendanceId = AttendanceOutSave(Convert.ToDateTime(endDateTime), attendanceId);
                    checkBox.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Message.IsSuccess = false;
                Message.Text = ex.Message;
            }
        }

        private int AttendanceOutSave(DateTime endDateTime, int attendanceId)
        {
            int AttendanceId;
            Model.Attendance attendance = new Model.Attendance()
            {
                AttendanceId = attendanceId,
                OutDateTime = endDateTime,
                CreatedBy = 1,
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Attendance = scope.Resolve<IAttendance>();
                AttendanceId = Attendance.Attendance_Out_Save(attendance);
            }
            if (AttendanceId > 0)
            {
                Message.IsSuccess = true;
                Message.Text = "Saved Successfully";
            }
            else
            {
                Message.IsSuccess = false;
                Message.Text = "Not saved.";
            }

            return AttendanceId;
        }

        protected void dgvStudentAttendance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Attendance = scope.Resolve<IAttendance>();
                    response = Attendance.Attendance_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    LoadAttendanceList();
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