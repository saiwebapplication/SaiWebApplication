using Autofac;
using Business.Utilities;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSai.Report
{
    public partial class EnrolmentReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Enrolment_GetAll();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Enrolment_GetAll();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtBatchId.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtEnrolmentId.Text = string.Empty;
            txtEnrolmentNo.Text = string.Empty;
            txtStudentId.Text = string.Empty;
            Enrolment_GetAll();
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvEnrolment, string.Format("Enrolment_{0}", DateTime.Now.Ticks));
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            GeneratePdf(dgvEnrolment, string.Format("Enrolment_{0}", DateTime.Now.Ticks));
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
                LoadEnrolmentList();

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
        private void GeneratePdf(GridView gridView, string filename)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.pdf", filename));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridView.AllowPaging = false;
            LoadEnrolmentList();
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
        private void Enrolment_GetAll()
        {
            DataTable dtEnrolment = LoadEnrolmentList();

            dgvEnrolment.DataSource = dtEnrolment;
            dgvEnrolment.DataBind();
        }
        private DataTable LoadEnrolmentList()
        {
            DataTable dtEnrolment;
            Model.Enrolment enrolment = new Model.Enrolment()
            {
                BatchId = Convert.ToInt32(string.IsNullOrEmpty(txtBatchId.Text) ? "0" : txtBatchId.Text.Trim()),
                EnrolmentId = Convert.ToInt32(string.IsNullOrEmpty(txtEnrolmentId.Text) ? "0" : txtEnrolmentId.Text.Trim()),
                EnrolmentNo = txtEnrolmentNo.Text.Trim(),
                StudentId = Convert.ToInt32(string.IsNullOrEmpty(txtStudentId.Text) ? "0" : txtStudentId.Text.Trim()),
                StartFromDate = (string.IsNullOrEmpty(txtStartDate.Text) ? DateTime.MinValue : Convert.ToDateTime(txtStartDate.Text)),
                StartToDate = (string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.MinValue : Convert.ToDateTime(txtEndDate.Text))
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Enrolment = scope.Resolve<IEnrolment>();
                dtEnrolment = Enrolment.Enrolment_GetAll(enrolment);
            }
            return dtEnrolment;
        }


    }
}