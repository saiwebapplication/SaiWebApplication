using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSai.UserControl
{
    public partial class ReportGrid : System.Web.UI.UserControl
    {
        public DataTable DataGrid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = DataGrid;
            GridView1.DataBind();
        }
    }
}