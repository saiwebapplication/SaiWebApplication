using Autofac;
using Business;
using Business.Utilities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSai.Report
{
    public partial class BatchReport : System.Web.UI.Page
    {
        private void Batch_GetAll()
        {
            DataTable dtMember = LoadBatchData();

            dgvBatch.DataSource = dtMember;
            dgvBatch.DataBind();
        }

        private DataTable LoadBatchData()
        {
            DataTable dtBatch;
            Model.Batch batch = new Model.Batch()
            {
                BatchName = txtBatchName.Text.Trim(),
                BranchId = Convert.ToInt32(ddlBranch.SelectedValue),
                ClassId = Convert.ToInt32(ddlClass.SelectedValue),
                HostId = Convert.ToInt32(ddlHost.SelectedValue),
                Year = Convert.ToInt32(ddlYear.SelectedValue)
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Batch = scope.Resolve<IBatch>();
                dtBatch = Batch.Batch_GetAll(batch);
            }

            return dtBatch;
        }

        private void LoadYearList()
        {
            using (DataTable dtYear = new DataTable())
            {
                dtYear.Columns.Add("Year");
                for (int year = 2019; year <= 2050; year++)
                {
                    DataRow drYear = dtYear.NewRow();
                    drYear["Year"] = year;
                    dtYear.Rows.Add(drYear);
                    dtYear.AcceptChanges();
                }

                ddlYear.DataSource = dtYear;
                ddlYear.DataValueField = "Year";
                ddlYear.DataTextField = "Year";
                ddlYear.DataBind();
            }
            ddlYear.InsertAll();
        }

        private void LoadHostList()
        {
            DataTable dtHost;
            Model.Host host = new Model.Host() { };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Host = scope.Resolve<IHost>();
                dtHost = Host.Host_GetAll(host);
            }
            if (dtHost != null)
            {
                ddlHost.DataSource = dtHost;
                ddlHost.DataValueField = "HostId";
                ddlHost.DataTextField = "HostName";
                ddlHost.DataBind();
            }
            ddlHost.InsertAll();
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
            ddlClass.InsertAll();
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
            ddlBranch.InsertAll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Branch_GetAll();
                LoadYearList();
                LoadClassList();
                LoadHostList();
                Batch_GetAll();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtBatchName.Text = string.Empty;
            ddlYear.SelectedIndex = 0;
            ddlHost.SelectedIndex = 0;
            ddlClass.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            Batch_GetAll();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Batch_GetAll();
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            GeneratePdf(dgvBatch, string.Format("Batch_{0}", DateTime.Now.Ticks));
        }

        private void GeneratePdf(GridView gridView, string filename)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.pdf", filename));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridView.AllowPaging = false;
            LoadBatchData();
            gridView.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        private void ExportToExcel(GridView gridView, string filename)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.xls", filename));
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                gridView.AllowPaging = false;
                LoadBatchData();

                gridView.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gridView.HeaderRow.Cells)
                {
                    cell.BackColor = gridView.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gridView.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gridView.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gridView.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gridView.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvBatch, string.Format("Batch_{0}", DateTime.Now.Ticks));
        }
    }
}