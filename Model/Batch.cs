using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Batch
    {
        public Batch()
        {

        }

        public int BatchId { get; set; }
        public int ClassId { get; set; }
        public string BatchName { get; set; }
        public string Description { get; set; }
        public int BranchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Year { get; set; }
        public int HostId { get; set; }
        public bool IsCompleted { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
