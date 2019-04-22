using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Batch : IBatch
    {
        public int Batch_Save(Model.Batch batch)
        {
            int BatchId = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Batch_Save";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BatchId", batch.BatchId).Direction = ParameterDirection.InputOutput; ;
                    if (batch.ClassId == 0)
                        cmd.Parameters.AddWithValue("@ClassId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@ClassId", batch.ClassId);
                    cmd.Parameters.AddWithValue("@BatchName", batch.BatchName);
                    cmd.Parameters.AddWithValue("@Description", batch.Description);
                    cmd.Parameters.AddWithValue("@BranchId", batch.BranchId);
                    cmd.Parameters.AddWithValue("@StartDate", batch.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", batch.EndDate);
                    cmd.Parameters.AddWithValue("@Year", batch.Year);
                    cmd.Parameters.AddWithValue("@HostId", batch.HostId);
                    cmd.Parameters.AddWithValue("@IsComplete", batch.IsCompleted);
                    cmd.Parameters.AddWithValue("@CreatedBy", batch.CreatedBy);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    BatchId = Convert.ToInt32(cmd.Parameters["@BatchId"].Value);
                    con.Close();
                }
            }
            return BatchId;
        }

        public DataTable Batch_GetAll(Model.Batch batch)
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_Batch_GetAll";
                        if (batch.BatchId == 0)
                            cmd.Parameters.AddWithValue("@BatchId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@BatchId", batch.BatchId);
                        if (string.IsNullOrEmpty(batch.BatchName))
                            cmd.Parameters.AddWithValue("@BatchName", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@BatchName", batch.BatchName);
                        if (batch.BranchId == 0)
                            cmd.Parameters.AddWithValue("@BranchId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@BranchId", batch.BranchId);
                        if (batch.Year == 0)
                            cmd.Parameters.AddWithValue("@Year", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Year", batch.Year);
                        if (batch.HostId == 0)
                            cmd.Parameters.AddWithValue("@HostId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@HostId", batch.HostId);
                        if (batch.ClassId == 0)
                            cmd.Parameters.AddWithValue("@ClassId", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@ClassId", batch.ClassId);
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

        public int Batch_Delete(int batchId)
        {
            int rowsAffacted = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "usp_Batch_Delete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BatchId", batchId);
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
