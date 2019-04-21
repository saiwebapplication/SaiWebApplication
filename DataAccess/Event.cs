using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccess
{
    public class Event : IEvent
    {
        public int Event_Delete(int eventId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_HR_Event_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    rowsAffacted = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowsAffacted;
        }

        public DataTable Event_GetAll(Model.Event evnt)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_HR_Event_GetAll";
                        if (evnt.EventId == 0)
                            cmd.Parameters.AddWithValue("@EventId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EventId", evnt.EventId);
                        if (evnt.EventTypeId == 0)
                            cmd.Parameters.AddWithValue("@EventTypeId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EventTypeId", evnt.EventTypeId);
                        if (string.IsNullOrEmpty(evnt.EventName))
                            cmd.Parameters.AddWithValue("@EventName", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EventName", evnt.EventName);
                        if (evnt.EventStartDate == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@EventFromDate", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EventFromDate", evnt.EventStartDate);
                        if (evnt.EventEndDate == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@EventToDate", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@EventToDate", evnt.EventEndDate);
                        if (evnt.BranchId == 0)
                            cmd.Parameters.AddWithValue("@BranchId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@BranchId", evnt.BranchId);
                        if (string.IsNullOrEmpty(evnt.Venue))
                            cmd.Parameters.AddWithValue("@Venue", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Venue", evnt.Venue);
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

        public int Event_Save(Model.Event evnt)
        {
            int eventId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_HR_Event_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EventId", evnt.EventId).Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.AddWithValue("@EventTypeId", evnt.EventTypeId);
                    cmd.Parameters.AddWithValue("@EventName", evnt.EventName);
                    cmd.Parameters.AddWithValue("@Description", evnt.Description);
                    cmd.Parameters.AddWithValue("@EventStartDate", evnt.EventStartDate);
                    cmd.Parameters.AddWithValue("@EventEndDate", evnt.EventEndDate);
                    cmd.Parameters.AddWithValue("@BranchId", evnt.BranchId);
                    cmd.Parameters.AddWithValue("@Venue", evnt.Venue);
                    cmd.Parameters.AddWithValue("@CreatedBy", evnt.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    eventId = Convert.ToInt32(cmd.Parameters["@EventId"].Value);
                    con.Close();
                }
            }
            return eventId;
        }
    }
}
