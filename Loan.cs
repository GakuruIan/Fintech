using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech
{
    public class Loan
    {
        public int AccountNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime Application_Date { get; set; }
        public DateTime Due { get; set; }
        public int ApprovedBy { get; set; }
        public string Approved_State { get; set; }
        public string Grantee_Name { get; set; }
        public int Grantee_ID { get; set; }
        public int Grantee_AccountNo { get; set; }
        public int Grantee_PhoneNO { get; set; }
        public string Assets { get; set; }
        public string state {get;set;}
    }
}

	