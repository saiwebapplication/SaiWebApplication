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
    public partial class EventReport : System.Web.UI.Page
    {
        private void Event_GetAll()
        {
            DataTable dtMember = LoadEventData();

            dgvEvent.DataSource = dtMember;
            dgvEvent.DataBind();
        }

        private DataTable LoadEventData()
        {
            DataTable dtEvent;
            Model.Event even = new Model.Event()
            {
                EventName = txtEventName.Text.Trim(),
                BranchId = Convert.ToInt32(ddlBranch.SelectedValue),
                EventTypeId = Convert.ToInt32(ddlEventType.SelectedValue),
                EventStartDate = (string.IsNullOrEmpty(txtEventStartDate.Text) ? DateTime.MinValue : Convert.ToDateTime(txtEventStartDate.Text)),
                EventEndDate = (string.IsNullOrEmpty(txtEventEndDate.Text) ? DateTime.MinValue : Convert.ToDateTime(txtEventEndDate.Text)),
            };
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var Event = scope.Resolve<IEvent>();
                dtEvent = Event.Event_GetAll(even);
            }
            return dtEvent;
        }

        private void LoadEventType()
        {
            DataTable dtEventType;
            using (var scope = Startup.Container.BeginLifetimeScope())
            {
                var EventType = scope.Resolve<IEventType>();
                dtEventType = EventType.EventType_GetAll();
            }
            if (dtEventType != null)
            {
                ddlEventType.DataSource = dtEventType;
                ddlEventType.DataTextField = "EventTypeName";
                ddlEventType.DataValueField = "EventTypeId";
                ddlEventType.DataBind();
            }
            ddlEventType.InsertAll();
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
                LoadEventType();
                Branch_GetAll();
                Event_GetAll();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEventName.Text = string.Empty;
            ddlBranch.SelectedIndex = 0;
            ddlEventType.SelectedIndex = 0;
            ddlBranch.SelectedIndex = 0;
            txtEventEndDate.Text = string.Empty;
            txtEventStartDate.Text = string.Empty;
            txtVenue.Text = string.Empty;
            Event_GetAll();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Event_GetAll();
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            GeneratePdf(dgvEvent, string.Format("Event_{0}", DateTime.Now.Ticks));
        }

        private void GeneratePdf(GridView gridView, string filename)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}.pdf", filename));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gridView.AllowPaging = false;
            LoadEventData();
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
                LoadEventData();

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
            ExportToExcel(dgvEvent, string.Format("Event_{0}", DateTime.Now.Ticks));
        }
    }
}