using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Host
    {
        public Host()
        {

        }

        public int HostId { get; set; }
        public string HostName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ContactNos { get; set; }
        public string Maplocation { get; set; }
        public bool IsActive { get; set; }
    }
}
