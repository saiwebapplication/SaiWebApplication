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
    public partial class RoleAccessLevel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRoles();
                LoadRoleAccessLevel();
            }
        }

        private void LoadRoles()
        {
            DataTable dtRole;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var role = scope.Resolve<IRole>();
                dtRole = role.Role_GetAll();
            }
            if (dtRole != null)
            {
                ddlRole.DataSource = dtRole;
                ddlRole.DataBind();
            }
        }

        private void LoadRoleAccessLevel()
        {
            UncheckAll();
            int RoleId = Convert.ToInt32(ddlRole.SelectedValue);
            DataTable dtRoleAccessLevel;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var role = scope.Resolve<IRoleAccessLevel>();
                dtRoleAccessLevel = role.RoleAccessLevel_GetByRoleId(RoleId);
            }
            foreach (DataRow dr in dtRoleAccessLevel.Rows)
            {
                if (ChkControlPanel.Items.FindByValue(dr["PermissionId"].ToString()) != null)
                    ChkControlPanel.Items.FindByValue(dr["PermissionId"].ToString()).Selected = true;
                if (chkMainMenu.Items.FindByValue(dr["PermissionId"].ToString()) != null)
                    chkMainMenu.Items.FindByValue(dr["PermissionId"].ToString()).Selected = true;
            }
        }

        private void UncheckAll()
        {
            foreach (ListItem lstItem in ChkControlPanel.Items)
                lstItem.Selected = false;
            foreach (ListItem lstItem in chkMainMenu.Items)
                lstItem.Selected = false;
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoleAccessLevel();
        }

        protected void CheckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(Request.Form["__EVENTTARGET"].Substring(Request.Form["__EVENTTARGET"].LastIndexOf('$') + 1));
            CheckBoxList cbl = (CheckBoxList)sender;
            int PermissionId = int.Parse(cbl.Items[index].Value);
            SaveRoleAccessLevel(PermissionId, cbl.Items[index].Selected);
        }

        private void SaveRoleAccessLevel(int PermissionId, bool IsChecked)
        {
            int RoleId = Convert.ToInt32(ddlRole.SelectedValue);
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var role = scope.Resolve<IRoleAccessLevel>();
                role.RoleAccessLevel_Save(RoleId, PermissionId, IsChecked);
            }
        }
    }
}