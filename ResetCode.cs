using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech
{
    public class ResetCode
    {
        public int id { get; set; }
        public string Code { get; set; }
        public int AccountNo { get; set; }
        public DateTime CodeExpiration { get; set; }
        public int Isused { get; set; }
    }
}
