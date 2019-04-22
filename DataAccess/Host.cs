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
    public class Host : IHost
    {
        public int Host_Save(Model.Host host)
        {
            int hostId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Host_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HostId", host.HostId).Direction = ParameterDirection.InputOutput; ;
                    cmd.Parameters.AddWithValue("@HostName", host.HostName);
                    cmd.Parameters.AddWithValue("@Description", host.Description);
                    cmd.Parameters.AddWithValue("@Location", host.Location);
                    cmd.Parameters.AddWithValue("@ContactNos", host.ContactNos);
                    cmd.Parameters.AddWithValue("@MapLocation", host.Maplocation);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    hostId = Convert.ToInt32(cmd.Parameters["@HostId"].Value);
                    con.Close();
                }
            }
            return hostId;
        }

        public DataTable Host_GetAll(Model.Host host)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_Host_GetAll";
                        if (host.HostId == 0)
                            cmd.Parameters.AddWithValue("@HostId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@HostId", host.HostId);
                        if (string.IsNullOrEmpty(host.HostName))
                            cmd.Parameters.AddWithValue("@HostName", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@HostName", host.HostName);
                        if (string.IsNullOrEmpty(host.ContactNos))
                            cmd.Parameters.AddWithValue("@ContactNo", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@ContactNo", host.ContactNos);
                        if (con.State == ConnectionState.Closed)
                            con.Open();
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

        public int Host_Delete(int hostId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Host_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HostId", hostId);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }
    }
}
