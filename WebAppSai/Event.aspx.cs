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
    public partial class Event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EventType_GetAll();
                Branch_GetAll();
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
                //ddlMemberType.DataSource = dtEventType;
                //ddlMemberType.DataTextField = "MemberTypeName";
                //ddlMemberType.DataValueField = "MemberTypeId";
                //ddlMemberType.DataBind();
            }
            //ddlMemberType.InsertSelect();
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
                
            }
        }
    }
}