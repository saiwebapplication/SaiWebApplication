using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Business
{
    public static class Context
    {
        public static string UserName
        {
            get
            {
                return (HttpContext.Current.Session["UserName"] != null) ? HttpContext.Current.Session["UserName"].ToString() : string.Empty;
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
    }
}
