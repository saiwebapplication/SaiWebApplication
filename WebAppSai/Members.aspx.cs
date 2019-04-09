using Autofac;
using Business;
using Business.Utilities;
using System;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace WebAppSai
{
    public partial class Members : System.Web.UI.Page
    {
        public int MemberId
        {
            get { return Convert.ToInt32(ViewState["MemberId"]); }
            set { ViewState["MemberId"] = value; }
        }

        public int MemberAddressDetailsId
        {
            get { return Convert.ToInt32(ViewState["MemberAddressDetailsId"]); }
            set { ViewState["MemberAddressDetailsId"] = value; }
        }

        public int MemberJobDetailsId
        {
            get { return Convert.ToInt32(ViewState["MemberJobDetailsId"]); }
            set { ViewState["MemberJobDetailsId"] = value; }
        }

        public int MemberActivityId
        {
            get { return Convert.ToInt32(ViewState["MemberActivityId"]); }
            set { ViewState["MemberActivityId"] = value; }
        }

        public int MemberRelationMappingId
        {
            get { return Convert.ToInt32(ViewState["MemberRelationMappingId"]); }
            set { ViewState["MemberRelationMappingId"] = value; }
        }

        private void Member_GetAll()
        {
            DataTable dtMember;
            Model.Member member = new Model.Member()
            {
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Member = scope.Resolve<IMember>();
                dtMember = Member.Member_GetAll(member);
            }

            dgvMember.DataSource = dtMember;
            dgvMember.DataBind();

            ddlPerson.DataSource = dtMember;
            ddlPerson.DataTextField = "NAME";
            ddlPerson.DataValueField = "MemberId";
            ddlPerson.DataBind();
            ddlPerson.InsertSelect();
        }

        private void Member_GetById()
        {
            DataTable dtMember;
            Model.Member member = new Model.Member()
            {
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Member = scope.Resolve<IMember>();
                dtMember = Member.Member_GetAll(member);
            }
            if (dtMember != null && dtMember.Rows.Count > 0)
            {
                txtBarcodeNo.Text = dtMember.Rows[0]["BarCodeNo"].ToString();
                txtCardId.Text = dtMember.Rows[0]["CardId"].ToString();
                txtDOB.Text = (dtMember.Rows[0]["DOB"] == DBNull.Value) ? "" : Convert.ToDateTime(dtMember.Rows[0]["DOB"].ToString()).ToString("dd MMM yyyy");
                txtEmailId.Text = dtMember.Rows[0]["PersonalEmail"].ToString();
                txtFirstName.Text = dtMember.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dtMember.Rows[0]["LastName"].ToString();
                txtMobileNo.Text = dtMember.Rows[0]["PersonalMobile"].ToString();
                ddlOccupation.SelectedValue = (dtMember.Rows[0]["OccupationId"] == DBNull.Value) ? "0" : dtMember.Rows[0]["OccupationId"].ToString();
                ddlSalutation.SelectedValue = dtMember.Rows[0]["Salutation"].ToString();
                rbtnGender.SelectedValue = dtMember.Rows[0]["Gender"].ToString();
            }
        }

        private void MemberAddress_GetAll()
        {
            DataTable dtMemberAddress;
            Model.MemberAddress memberAddress = new Model.MemberAddress()
            {
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberAddress = scope.Resolve<IMemberAddress>();
                dtMemberAddress = MemberAddress.MemberAddress_GetAll(memberAddress);
            }

            gvAddress.DataSource = dtMemberAddress;
            gvAddress.DataBind();
        }

        private void MemberAddress_GetById()
        {
            DataTable dtMemberAddress;
            Model.MemberAddress memberAddress = new Model.MemberAddress()
            {
                MemberAddressDetailsId = this.MemberAddressDetailsId,
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberAddress = scope.Resolve<IMemberAddress>();
                dtMemberAddress = MemberAddress.MemberAddress_GetAll(memberAddress);
            }
            if (dtMemberAddress != null && dtMemberAddress.Rows.Count > 0)
            {
                txtResidentialAddress.Text = dtMemberAddress.Rows[0]["ResidentialAddress"].ToString();
                txtEmirates.Text = dtMemberAddress.Rows[0]["Emirates"].ToString();
                ddlLocality.SelectedValue = (dtMemberAddress.Rows[0]["LocalityId"] == DBNull.Value) ? "0" : dtMemberAddress.Rows[0]["LocalityId"].ToString();
            }
        }

        private void Occupation_GetAll()
        {
            DataTable dtOccupation;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Occupation = scope.Resolve<IOccupation>();
                dtOccupation = Occupation.Occupation_GetAll();
            }
            if (dtOccupation != null)
            {
                ddlOccupation.DataSource = dtOccupation;
                ddlOccupation.DataTextField = "OccupationName";
                ddlOccupation.DataValueField = "OccupationId";
                ddlOccupation.DataBind();
            }
            ddlOccupation.InsertSelect();
        }

        private void LocalityMaster_GetAll()
        {
            DataTable dtLocality;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Locality = scope.Resolve<ILocalityMaster>();
                dtLocality = Locality.LocalityMaster_GetAll();
            }
            if (dtLocality != null)
            {
                ddlLocality.DataSource = dtLocality;
                ddlLocality.DataTextField = "LocalityName";
                ddlLocality.DataValueField = "LocalityId";
                ddlLocality.DataBind();
            }
            ddlLocality.InsertSelect();
        }

        private void Relation_GetAll()
        {
            DataTable dtRelation;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Relation = scope.Resolve<IRelation>();
                dtRelation = Relation.Relation_GetAll();
            }
            if (dtRelation != null)
            {
                ddlRelation.DataSource = dtRelation;
                ddlRelation.DataTextField = "RelationName";
                ddlRelation.DataValueField = "RelationId";
                ddlRelation.DataBind();
            }
            ddlRelation.InsertSelect();
        }

        private void MemberJob_GetAll()
        {
            DataTable dtMemberJob;
            Model.MemberJob memberJob = new Model.MemberJob()
            {
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberJob = scope.Resolve<IMemberJob>();
                dtMemberJob = MemberJob.MemberJob_GetAll(memberJob);
            }

            gvJob.DataSource = dtMemberJob;
            gvJob.DataBind();
        }

        private void MemberJob_GetById()
        {
            DataTable dtMemberJob;
            Model.MemberJob memberJob = new Model.MemberJob()
            {
                MemberJobDetailsId = this.MemberJobDetailsId,
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberJob = scope.Resolve<IMemberJob>();
                dtMemberJob = MemberJob.MemberJob_GetAll(memberJob);
            }
            if (dtMemberJob != null && dtMemberJob.Rows.Count > 0)
            {
                txtCompanyName.Text = dtMemberJob.Rows[0]["CompanyName"].ToString();
                txtCompanyAddress.Text = dtMemberJob.Rows[0]["CompanyAddress"].ToString();
                txtCompanyEmirates.Text = dtMemberJob.Rows[0]["Emirates"].ToString();
            }
        }

        private void ActivityMaster_GetAll()
        {
            DataTable dtActivityMaster;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var ActivityMaster = scope.Resolve<IActivityMaster>();
                dtActivityMaster = ActivityMaster.ActivityMaster_GetAll();
            }
            if (dtActivityMaster != null)
            {
                ddlActivity.DataSource = dtActivityMaster;
                ddlActivity.DataTextField = "ActivityName";
                ddlActivity.DataValueField = "ActivityMasterId";
                ddlActivity.DataBind();
            }
            ddlActivity.InsertSelect();
        }

        private void MemberActivity_GetAll()
        {
            DataTable dtMemberActivity;
            Model.MemberActivity memberActivity = new Model.MemberActivity()
            {
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberActivity = scope.Resolve<IMemberActivity>();
                dtMemberActivity = MemberActivity.MemberActivity_GetAll(memberActivity);
            }

            gvActivity.DataSource = dtMemberActivity;
            gvActivity.DataBind();
        }

        private void MemberActivity_GetById()
        {
            DataTable dtMemberActivity;
            Model.MemberActivity memberActivity = new Model.MemberActivity()
            {
                MemberActivityId = this.MemberActivityId,
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberActivity = scope.Resolve<IMemberActivity>();
                dtMemberActivity = MemberActivity.MemberActivity_GetAll(memberActivity);
            }
            if (dtMemberActivity != null && dtMemberActivity.Rows.Count > 0)
            {
                ddlActivity.SelectedValue = dtMemberActivity.Rows[0]["ActivityId"].ToString();
                txtLocation.Text = dtMemberActivity.Rows[0]["Location"].ToString();
                txtFromDate.Text = (dtMemberActivity.Rows[0]["FromDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(dtMemberActivity.Rows[0]["FromDate"].ToString()).ToString("dd MMM yyyy");
                txtToDate.Text = (dtMemberActivity.Rows[0]["ToDate"] == DBNull.Value) ? string.Empty : Convert.ToDateTime(dtMemberActivity.Rows[0]["ToDate"].ToString()).ToString("dd MMM yyyy");
                rbtnLikeActivity.SelectedValue = (dtMemberActivity.Rows[0]["LikeActivity"] == DBNull.Value) ? "1" : dtMemberActivity.Rows[0]["LikeActivity"].ToString();
            }
        }

        private void MemberRelationMapping_GetAll()
        {
            DataTable dtRelation;
            Model.MemberRelationMapping memberRelationMapping = new Model.MemberRelationMapping()
            {
                FirstMemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberRelationMapping = scope.Resolve<IMemberRelationMapping>();
                dtRelation = MemberRelationMapping.MemberRelationMapping_GetAll(memberRelationMapping);
            }

            gvRelation.DataSource = dtRelation;
            gvRelation.DataBind();
        }

        private void MemberRelationMapping_GetById()
        {
            DataTable dtRelation;
            Model.MemberRelationMapping memberRelationMapping = new Model.MemberRelationMapping()
            {
                MemberRelationMappingId = this.MemberRelationMappingId,
                FirstMemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberRelationMapping = scope.Resolve<IMemberRelationMapping>();
                dtRelation = MemberRelationMapping.MemberRelationMapping_GetAll(memberRelationMapping);
            }
            if (dtRelation != null && dtRelation.Rows.Count > 0)
            {
                ddlPerson.SelectedValue = dtRelation.Rows[0]["SecondMemberId"].ToString();
                ddlRelation.SelectedValue = dtRelation.Rows[0]["RelationId"].ToString();
            }
        }

        private void MemberSettings_GetById()
        {
            DataTable dtSettings;
            Model.MemberSettings memberSettings = new Model.MemberSettings()
            {
                MemberId = this.MemberId
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var MemberSettings = scope.Resolve<IMemberSettings>();
                dtSettings = MemberSettings.MemberSettings_GetById(memberSettings);
            }
            if (dtSettings != null && dtSettings.Rows.Count > 0)
            {
                rbtnIsActive.SelectedValue = (dtSettings.Rows[0]["IsActive"] == DBNull.Value) ? "False" : dtSettings.Rows[0]["IsActive"].ToString();
                rbtnIsAppLoginEnabled.SelectedValue = (dtSettings.Rows[0]["IsAppLoginEnabled"] == DBNull.Value) ? "False" : dtSettings.Rows[0]["IsAppLoginEnabled"].ToString();
                txtUserName.Text = dtSettings.Rows[0]["UserName"].ToString();
            }
        }

        private void Role_GetAll()
        {
            DataTable dtRoles;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Role = scope.Resolve<IRole>();
                dtRoles = Role.Role_GetAll();
            }

            chkRoles.DataSource = dtRoles;
            chkRoles.DataTextField = "RoleName";
            chkRoles.DataValueField = "RoleId";
            chkRoles.DataBind();
        }

        private void ClearMemberControls()
        {
            MemberId = 0;
            Message.Text = string.Empty;
            btnSave.Text = "Save";
            txtBarcodeNo.Text = string.Empty;
            txtCardId.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            ddlSalutation.SelectedIndex = 0;
            rbtnGender.SelectedIndex = 0;
        }

        private void ClearAddressControls()
        {
            MemberAddressDetailsId = 0;
            MessageAddress.Text = string.Empty;
            btnAddressSave.Text = "Save";
            txtResidentialAddress.Text = string.Empty;
            ddlLocality.SelectedIndex = 0;
            txtEmirates.Text = string.Empty;
        }

        private void ClearJobControls()
        {
            MemberJobDetailsId = 0;
            MessageJob.Text = string.Empty;
            btnJobSave.Text = "Save";
            txtCompanyAddress.Text = string.Empty;
            txtCompanyEmirates.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
        }

        private void ClearActivityControls()
        {
            MemberActivityId = 0;
            MessageActivity.Text = string.Empty;
            btnActivitySave.Text = "Save";
            ddlActivity.SelectedIndex = 0;
            txtLocation.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;
            rbtnLikeActivity.SelectedValue = "1";
        }

        private void ClearMemberRelationMappingControls()
        {
            MemberRelationMappingId = 0;
            MessageRelation.Text = string.Empty;
            btnRelationSave.Text = "Save";
            ddlPerson.SelectedIndex = 0;
            ddlRelation.SelectedIndex = 0;
        }

        private void ClearSettingsControls()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private bool ValidateAddress()
        {
            if (string.IsNullOrEmpty(txtResidentialAddress.Text.Trim()))
            {
                MessageAddress.IsSuccess = false;
                MessageAddress.Text = "Please enter residential address.";
                return false;
            }
            if (ddlLocality.SelectedIndex == 0)
            {
                MessageAddress.IsSuccess = false;
                MessageAddress.Text = "Please select locality.";
                return false;
            }
            if (string.IsNullOrEmpty(txtEmirates.Text.Trim()))
            {
                MessageAddress.IsSuccess = false;
                MessageAddress.Text = "Please enter emirate.";
                return false;
            }
            return true;
        }

        private bool ValidateJob()
        {
            if (string.IsNullOrEmpty(txtCompanyAddress.Text.Trim()))
            {
                MessageJob.IsSuccess = false;
                MessageJob.Text = "Please enter company address.";
                return false;
            }
            if (string.IsNullOrEmpty(txtCompanyEmirates.Text.Trim()))
            {
                MessageJob.IsSuccess = false;
                MessageJob.Text = "Please enter company emirates.";
                return false;
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
            {
                MessageJob.IsSuccess = false;
                MessageJob.Text = "Please enter company name.";
                return false;
            }
            return true;
        }

        private bool ValidateActivity()
        {
            if (ddlActivity.SelectedIndex == 0)
            {
                MessageActivity.IsSuccess = false;
                MessageActivity.Text = "Please select member activity.";
                return false;
            }
            return true;
        }

        private bool ValidateRelation()
        {
            if (ddlPerson.SelectedIndex == 0)
            {
                MessageRelation.IsSuccess = false;
                MessageRelation.Text = "Please select person.";
                return false;
            }
            if (ddlRelation.SelectedIndex == 0)
            {
                MessageRelation.IsSuccess = false;
                MessageRelation.Text = "Please select relation.";
                return false;
            }
            return true;
        }

        private bool ValidateSettings()
        {
            if (rbtnIsAppLoginEnabled.SelectedValue == "True")
            {
                if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
                {
                    MessageSettings.IsSuccess = false;
                    MessageSettings.Text = "Please enter username.";
                    return false;
                }

                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageSettings.IsSuccess = false;
                    MessageSettings.Text = "Please enter password.";
                    return false;
                }
            }
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Occupation_GetAll();
                Member_GetAll();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Model.Member member = new Model.Member()
                {
                    MemberId = this.MemberId,
                    BarcodeNo = txtBarcodeNo.Text.Trim(),
                    CardId = txtCardId.Text.Trim(),
                    CreatedBy = int.Parse(HttpContext.Current.User.Identity.Name),
                    Dob = (string.IsNullOrEmpty(txtDOB.Text.Trim())) ? DateTime.MinValue : Convert.ToDateTime(txtDOB.Text),
                    Email = txtEmailId.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    Gender = rbtnGender.Text,
                    LastName = txtLastName.Text.Trim(),
                    Mobile = txtMobileNo.Text.Trim(),
                    OccupationId = int.Parse(ddlOccupation.SelectedValue),
                    Salutation = ddlSalutation.SelectedValue,
                    Image = string.Empty
                };
                using (var scope = Startup.Container.BeginLifetimeScope())
                {
                    var Member = scope.Resolve<IMember>();
                    MemberId = Member.Member_Save(member);
                }
                if (MemberId > 0)
                {
                    ClearMemberControls();
                    Member_GetAll();
                    Message.IsSuccess = true;
                    Message.Text = "Saved Successfully";
                    Thread.Sleep(1000);
                    LocalityMaster_GetAll();
                    ModalPopupExtender1.Show();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAddressControls();
        }

        protected void dgvMember_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Ed")
                {
                    MemberId = Convert.ToInt32(e.CommandArgument.ToString());
                    Member_GetById();
                    btnSave.Text = "Update";
                }
                else if (e.CommandName == "Del")
                {
                    int response = 0;
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var Member = scope.Resolve<IMember>();
                        response = Member.Member_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    }
                    if (response > 0)
                    {
                        ClearAddressControls();
                        Member_GetAll();
                        Message.IsSuccess = true;
                        Message.Text = "Deleted Successfully";
                    }
                    else
                    {
                        Message.IsSuccess = false;
                        Message.Text = "Data Dependency Exists";
                    }
                }
                else if (e.CommandName == "Settings")
                {
                    MemberId = Convert.ToInt32(e.CommandArgument.ToString());
                    LocalityMaster_GetAll();
                    MemberAddress_GetAll();
                    TabContainer2.ActiveTabIndex = 0;
                    ClearActivityControls();
                    ClearAddressControls();
                    ClearJobControls();
                    ClearMemberRelationMappingControls();
                    ClearSettingsControls();
                    ModalPopupExtender1.Show();
                }
            }
            catch (Exception ex)
            {
                Message.IsSuccess = false;
                Message.Text = ex.Message;
            }
        }

        protected void gvAddress_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Ed")
                {
                    MemberAddressDetailsId = Convert.ToInt32(e.CommandArgument.ToString());
                    MemberAddress_GetById();
                    btnAddressSave.Text = "Update";
                }
                else if (e.CommandName == "Del")
                {
                    int response = 0;
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberAddress = scope.Resolve<IMemberAddress>();
                        response = MemberAddress.MemberAddress_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    }
                    if (response > 0)
                    {
                        ClearAddressControls();
                        MemberAddress_GetAll();
                        MessageAddress.IsSuccess = true;
                        MessageAddress.Text = "Deleted Successfully";
                    }
                    else
                    {
                        MessageAddress.IsSuccess = false;
                        MessageAddress.Text = "Data Dependency Exists";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageAddress.IsSuccess = false;
                MessageAddress.Text = ex.Message;
            }
            finally
            {
                ModalPopupExtender1.Show();
            }
        }

        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAddress())
                {
                    int response = 0;
                    Model.MemberAddress memberAddress = new Model.MemberAddress()
                    {
                        MemberAddressDetailsId = this.MemberAddressDetailsId,
                        MemberId = this.MemberId,
                        Emirates = txtEmirates.Text.Trim(),
                        LocalityId = int.Parse(ddlLocality.SelectedValue),
                        ResidentialAddress = txtResidentialAddress.Text.Trim(),
                        CreatedBy = int.Parse(HttpContext.Current.User.Identity.Name),
                    };
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberAddress = scope.Resolve<IMemberAddress>();
                        response = MemberAddress.MemberAddress_Save(memberAddress);
                    }
                    if (response > 0)
                    {
                        ClearAddressControls();
                        MemberAddress_GetAll();
                        MessageAddress.IsSuccess = true;
                        MessageAddress.Text = "Saved Successfully";
                    }
                    else
                    {
                        MessageAddress.IsSuccess = false;
                        MessageAddress.Text = "Not saved.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageAddress.IsSuccess = false;
                MessageAddress.Text = ex.Message;
            }
            finally { ModalPopupExtender1.Show(); }
        }

        protected void btnAddressCancel_Click(object sender, EventArgs e)
        {
            ClearAddressControls();
            ModalPopupExtender1.Show();
        }

        protected void btnJobSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateJob())
                {
                    int response = 0;
                    Model.MemberJob memberJob = new Model.MemberJob()
                    {
                        MemberJobDetailsId = this.MemberJobDetailsId,
                        MemberId = this.MemberId,
                        Emirates = txtCompanyEmirates.Text.Trim(),
                        CompanyAddress = txtCompanyAddress.Text.Trim(),
                        CompanyName = txtCompanyName.Text.Trim(),
                        CreatedBy = int.Parse(HttpContext.Current.User.Identity.Name),
                    };
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberJob = scope.Resolve<IMemberJob>();
                        response = MemberJob.MemberJob_Save(memberJob);
                    }
                    if (response > 0)
                    {
                        ClearJobControls();
                        MemberJob_GetAll();
                        MessageJob.IsSuccess = true;
                        MessageJob.Text = "Saved Successfully";
                    }
                    else
                    {
                        MessageJob.IsSuccess = false;
                        MessageJob.Text = "Not saved.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageJob.IsSuccess = false;
                MessageJob.Text = ex.Message;
            }
            finally { ModalPopupExtender1.Show(); }
        }

        protected void btnJobCancel_Click(object sender, EventArgs e)
        {
            ClearJobControls();
            ModalPopupExtender1.Show();
        }

        protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Ed")
                {
                    MemberJobDetailsId = Convert.ToInt32(e.CommandArgument.ToString());
                    MemberJob_GetById();
                    btnJobSave.Text = "Update";
                }
                else if (e.CommandName == "Del")
                {
                    int response = 0;
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberJob = scope.Resolve<IMemberJob>();
                        response = MemberJob.MemberJob_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    }
                    if (response > 0)
                    {
                        ClearJobControls();
                        MemberJob_GetAll();
                        MessageJob.IsSuccess = true;
                        MessageJob.Text = "Deleted Successfully";
                    }
                    else
                    {
                        MessageJob.IsSuccess = false;
                        MessageJob.Text = "Data Dependency Exists";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageJob.IsSuccess = false;
                MessageJob.Text = ex.Message;
            }
            finally
            {
                ModalPopupExtender1.Show();
            }
        }

        protected void btnActivitySave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateActivity())
                {
                    int response = 0;
                    Model.MemberActivity memberActivity = new Model.MemberActivity()
                    {
                        MemberActivityId = this.MemberActivityId,
                        MemberId = this.MemberId,
                        ActivityId = int.Parse(ddlActivity.SelectedValue),
                        FromDate = (string.IsNullOrEmpty(txtFromDate.Text.Trim())) ? DateTime.MinValue : Convert.ToDateTime(txtFromDate.Text.Trim()),
                        ToDate = (string.IsNullOrEmpty(txtToDate.Text.Trim())) ? DateTime.MinValue : Convert.ToDateTime(txtToDate.Text.Trim()),
                        LikeActivity = Convert.ToBoolean(rbtnLikeActivity.SelectedValue),
                        Location = txtLocation.Text.Trim(),
                        CreatedBy = int.Parse(HttpContext.Current.User.Identity.Name),
                    };
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberActivity = scope.Resolve<IMemberActivity>();
                        response = MemberActivity.MemberActivity_Save(memberActivity);
                    }
                    if (response > 0)
                    {
                        ClearActivityControls();
                        MemberActivity_GetAll();
                        MessageActivity.IsSuccess = true;
                        MessageActivity.Text = "Saved Successfully";
                    }
                    else
                    {
                        MessageActivity.IsSuccess = false;
                        MessageActivity.Text = "Not saved.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageActivity.IsSuccess = false;
                MessageActivity.Text = ex.Message;
            }
            finally { ModalPopupExtender1.Show(); }
        }

        protected void btnActivityCancel_Click(object sender, EventArgs e)
        {
            ClearActivityControls();
            ModalPopupExtender1.Show();
        }

        protected void gvActivity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Ed")
                {
                    MemberActivityId = Convert.ToInt32(e.CommandArgument.ToString());
                    MemberActivity_GetById();
                    btnActivitySave.Text = "Update";
                }
                else if (e.CommandName == "Del")
                {
                    int response = 0;
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberActivity = scope.Resolve<IMemberActivity>();
                        response = MemberActivity.MemberActivity_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    }
                    if (response > 0)
                    {
                        ClearActivityControls();
                        MemberActivity_GetAll();
                        MessageActivity.IsSuccess = true;
                        MessageActivity.Text = "Deleted Successfully";
                    }
                    else
                    {
                        MessageActivity.IsSuccess = false;
                        MessageActivity.Text = "Data Dependency Exists";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageActivity.IsSuccess = false;
                MessageActivity.Text = ex.Message;
            }
            finally
            {
                ModalPopupExtender1.Show();
            }
        }

        protected void btnRelationSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateRelation())
                {
                    int response = 0;
                    Model.MemberRelationMapping memberRelationMapping = new Model.MemberRelationMapping()
                    {
                        FirstMemberId = MemberId,
                        MemberRelationMappingId = this.MemberRelationMappingId,
                        RelationId = int.Parse(ddlRelation.SelectedValue),
                        SecondMemberId = int.Parse(ddlPerson.SelectedValue)
                    };
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberRelationMapping = scope.Resolve<IMemberRelationMapping>();
                        response = MemberRelationMapping.MemberRelationMapping_Save(memberRelationMapping);
                    }
                    if (response > 0)
                    {
                        ClearMemberRelationMappingControls();
                        MemberRelationMapping_GetAll();
                        MessageRelation.IsSuccess = true;
                        MessageRelation.Text = "Saved Successfully";
                    }
                    else
                    {
                        MessageRelation.IsSuccess = false;
                        MessageRelation.Text = "Not saved.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageRelation.IsSuccess = false;
                MessageRelation.Text = ex.Message;
            }
            finally { ModalPopupExtender1.Show(); }
        }

        protected void btnRelationCancel_Click(object sender, EventArgs e)
        {
            ClearMemberRelationMappingControls();
            ModalPopupExtender1.Show();
        }

        protected void gvRelation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Ed")
                {
                    MemberRelationMappingId = Convert.ToInt32(e.CommandArgument.ToString());
                    MemberRelationMapping_GetById();
                    btnRelationSave.Text = "Update";
                }
                else if (e.CommandName == "Del")
                {
                    int response = 0;
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberRelationMapping = scope.Resolve<IMemberRelationMapping>();
                        response = MemberRelationMapping.MemberRelationMapping_Delete(Convert.ToInt32(e.CommandArgument.ToString()));
                    }
                    if (response > 0)
                    {
                        ClearMemberRelationMappingControls();
                        MemberRelationMapping_GetAll();
                        MessageRelation.IsSuccess = true;
                        MessageRelation.Text = "Deleted Successfully";
                    }
                    else
                    {
                        MessageRelation.IsSuccess = false;
                        MessageRelation.Text = "Data Dependency Exists";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageRelation.IsSuccess = false;
                MessageRelation.Text = ex.Message;
            }
            finally
            {
                ModalPopupExtender1.Show();
            }
        }

        protected void TabContainer2_ActiveTabChanged(object sender, EventArgs e)
        {
            switch (TabContainer2.ActiveTabIndex)
            {
                case 0:
                    LocalityMaster_GetAll();
                    MemberAddress_GetAll();
                    break;
                case 1:
                    MemberJob_GetAll();
                    break;
                case 2:
                    ActivityMaster_GetAll();
                    MemberActivity_GetAll();
                    break;
                case 3:
                    Relation_GetAll();
                    MemberRelationMapping_GetAll();
                    break;
                case 4:
                    MemberSettings_GetById();
                    Role_GetAll();
                    break;
            }
            ModalPopupExtender1.Show();
        }

        protected void rbtnIsAppLoginEnabled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnIsAppLoginEnabled.SelectedValue == "False")
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
            ModalPopupExtender1.Show();
        }

        protected void btnSettingsSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSettings())
                {
                    int response = 0;
                    Model.MemberSettings memberSettings = new Model.MemberSettings()
                    {
                        CreatedBy = int.Parse(HttpContext.Current.User.Identity.Name),
                        IsActive = bool.Parse(rbtnIsActive.SelectedValue),
                        IsAppLoginEnabled = bool.Parse(rbtnIsAppLoginEnabled.SelectedValue),
                        MemberId = this.MemberId,
                        Password = txtPassword.Text,
                        UserName = txtUserName.Text.Trim()
                    };
                    using (var scope = Startup.Container.BeginLifetimeScope())
                    {
                        var MemberSettings = scope.Resolve<IMemberSettings>();
                        response = MemberSettings.MemberSettings_Save(memberSettings);
                    }
                    if (response > 0)
                    {
                        ClearSettingsControls();
                        MemberSettings_GetById();
                        MessageSettings.IsSuccess = true;
                        MessageSettings.Text = "Saved Successfully";
                    }
                    else
                    {
                        MessageSettings.IsSuccess = false;
                        MessageSettings.Text = "Not saved.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageSettings.IsSuccess = false;
                MessageSettings.Text = ex.Message;
            }
            finally { ModalPopupExtender1.Show(); }
        }
    }
}