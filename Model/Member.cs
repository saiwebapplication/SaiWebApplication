using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Member
    {
        public Member()
        {

        }

        public int MemberId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BarcodeNo { get; set; }
        public string CardId { get; set; }
        public int OccupationId { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public DateTime Dob { get; set; }
        public int CreatedBy { get; set; }
    }
}
