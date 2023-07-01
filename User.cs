using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech
{
    public  class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int NationalID { get; set; }
        public string Residence { get; set; }
        public string Branch { get; set; }
        public int AccountNo { get; set; }
        public DateTime create_Date { get; set; }
        public string Fullname
        {
            get
            {
                return $"{Firstname} " + $"{Lastname}";
            }
        }
    }
}
