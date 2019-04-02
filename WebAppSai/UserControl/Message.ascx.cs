using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSai.UserControl
{
    public partial class Message : System.Web.UI.UserControl
    {
        public bool IsSuccess { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Text
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    spanSuccess.Visible = false;
                    spanError.Visible = false;
                    return;
                }
                if (IsSuccess == true)
                {
                    lblSuccess.Text = value;
                    spanSuccess.Visible = true;
                    spanError.Visible = false;
                }
                else
                {
                    lblError.Text = value;
                    spanSuccess.Visible = false;
                    spanError.Visible = true;
                }
            }
        }
    }
}