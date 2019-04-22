using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public class Host : IHost
    {
        DataAccess.IHost _Host;

        public Host(DataAccess.IHost host)
        {
            this._Host = host;
        }

        public int Host_Save(Model.Host host)
        {
            return _Host.Host_Save(host);

        }

        public DataTable Host_GetAll(Model.Host host)
        {
            return _Host.Host_GetAll(host);
        }

        public int Host_Delete(int hostId)
        {
            return _Host.Host_Delete(hostId);
        }
    }
}
