using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleAccessLevel : IRoleAccessLevel
    {
        public void RoleAccessLevel_Save(int RoleId, int PermissionId, bool isChecked)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_RoleAccessLevel_Save";

                    cmd.Parameters.AddWithValue("@RoleId", RoleId);
                    cmd.Parameters.AddWithValue("@PermissionId", PermissionId);
                    cmd.Parameters.AddWithValue("@Checked", isChecked);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public DataTable RoleAccessLevel_GetByRoleId(int RoleId)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_RoleAccessLevel_GetByRoleId";

                        cmd.Parameters.AddWithValue("@RoleId", RoleId);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                }
                return dt;
            }
        }
    }
}
