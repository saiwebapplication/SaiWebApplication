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
    public partial class HostReport : System.Web.UI.Page
    {
        private void Host_GetAll()
        {
            DataTable dtMember = LoadHostData();

            dgvHost.DataSource = dtMember;
            dgvHost.DataBind();
        }

        private DataTable LoadHostData()
        {
            DataTable dtHost;
            Model.Host host = new Model.Host()
            {
                ContactNos=txtContactNo.Text.Trim(),
                HostName = txtHostName.Text.Trim()
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Host = scope.Resolve<IHost>();
                dtHost = Host.Host_GetAll(host);
            }
            return dtHost;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Host_GetAll();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtContactNo.Text = string.Empty;
            txtHostName.Text = string.Empty;
            Host_GetAll();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Host_GetAll();
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            GeneratePdf(dgvHost, string.Format("Host_{0}", DateTime.Now.Ticks));
        }

        private void GeneratePdf(GridView gridView, string filename)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.pdf", filename));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridView.AllowPaging = false;
            LoadHostData();
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
                LoadHostData();

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
            ExportToExcel(dgvHost, string.Format("Host_{0}", DateTime.Now.Ticks));
        }
    }
}