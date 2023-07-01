using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech
{
   public  class Transcation
    {
        public string TranscationID { get; set; }
        public string TranscationType { get; set; }
        public string Reciepent_Name { get; set; }
        public int Reciepent_Acc { get; set; }
        public int AccountNo { get; set; }
        public DateTime Transcation_Date { get; set; }
    }
}
