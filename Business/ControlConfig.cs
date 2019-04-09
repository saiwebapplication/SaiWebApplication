using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Business
{
    public static class ControlConfig
    {
        public static void InsertSelect(this DropDownList dropDownList)
        {
            dropDownList.Items.Insert(0, new ListItem() { Text = "--Select--", Value = "0", Selected = true, Enabled = true });
        }
    }
}
