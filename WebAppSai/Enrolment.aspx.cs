using Autofac;
using Business;
using Business.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace WebAppSai
{
    public partial class Enrolment : System.Web.UI.Page
    {
        public int EnrolmentId
        {
            get { return Convert.ToInt32(ViewState["EnrolmentId"]); }
            set { ViewState["EnrolmentId"] = value; }
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
            }
            ddlBatch.InsertSelect();
        }
        private void ClearControls()
        {
            EnrolmentId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            ddlClass.SelectedIndex = 0;
            ddlBatch.SelectedIndex = 0;
            txtEnrolmentNo.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            txtStartDate.Text = string.Empty;
        }

        private void LoadEnrolmentList()
        {
            DataTable dtEnrolment;
            Model.Enrolment enrolment = new Model.Enrolment() { };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Enrolment = scope.Resolve<IEnrolment>();
                dtEnrolment = Enrolment.Enrolment_GetAll(enrolment);
            }
            if (dtEnrolment != null)
            {
                dgvEnrolment.DataSource = dtEnrolment;
                dgvEnrolment.DataBind();
            }
        }

        private void LoadEnrolmentById()
        {
            DataTable dtEnrolment;
            Model.Enrolment enrolment = new Model.Enrolment()
            {
                EnrolmentId = this.EnrolmentId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Enrolment = scope.Resolve<IEnrolment>();
                dtEnrolment = Enrolment.Enrolment_GetAll(enrolment);
            }
            if (dtEnrolment != null && dtEnrolment.Rows.Count > 0)
            {
                txtEnrolmentNo.Text = dtEnrolment.Rows[0]["EnrolmentNo"].ToString();
                txtStartDate.Text = Convert.ToDateTime(dtEnrolment.Rows[0]["StartDate"].ToString()).ToString("dd MMM yyyy");
                txtStudentName.Text= dtEnrolment.Rows[0]["Name"].ToString();
                ddlBatch.SelectedValue = dtEnrolment.Rows[0]["BatchId"].ToString();
                ddlClass.SelectedValue = dtEnrolment.Rows[0]["ClassId"].ToString();
                hfStudentId.Value = dtEnrolment.Rows[0]["StudentId"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClassList();
                LoadBatchList();
                LoadEnrolmentList();
            }
        }

        [WebMethod]
        public static string[] GetStudents(string prefix)
        {
            List<string> customers = new List<string>();
            foreach (DataRow dr in Member_GetAll(prefix).Rows)
            {
                customers.Add(string.Format("{0}-{1}", dr["Name"], dr["MemberId"]));
            }
            return customers.ToArray();
        }

        private static DataTable Member_GetAll(string name)
        {
            DataTable dtMember;
            Model.Member member = new Model.Member()
            {
                FirstName = name.Trim()
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Member = scope.Resolve<IMember>();
                dtMember = Member.Member_GetAll(member);
            }

            return dtMember;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int response = 0;
            Model.Enrolment enrolment = new Model.Enrolment()
            {
                BatchId = Convert.ToInt32(ddlBatch.SelectedValue),
                CreatedBy = 1,
                EnrolmentId = this.EnrolmentId,
                EnrolmentNo = txtEnrolmentNo.Text.Trim(),
                StartDate = Convert.ToDateTime(txtStartDate.Text),
                StudentId = Convert.ToInt32(hfStudentId.Value)
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Enrolment = scope.Resolve<IEnrolment>();
                response = Enrolment.Enrolment_Save(enrolment);
            }
            if (response > 0)
            {
                ClearControls();
                LoadEnrolmentList();
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

        protected void dgvEnrolment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ed")
            {
                EnrolmentId = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);

                LoadEnrolmentById();
                btnSave.Text = "Update";
            }
            else if (e.CommandName == "Del")
            {
                int response = 0;
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Enrolment = scope.Resolve<IEnrolment>();
                    response = Enrolment.Enrolment_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                }
                if (response > 0)
                {
                    ClearControls();
                    LoadEnrolmentList();
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

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBatchList();
        }
    }
}