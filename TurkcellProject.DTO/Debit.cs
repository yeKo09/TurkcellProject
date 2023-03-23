using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Debit
    {

        public int DebitID { get; set; }

        public int DebitReasonID { get; set; }

        public int DebitTypeID { get; set; }

        public DateTime DebitStartDate { get; set; }

        public DateTime DebitEndDate { get; set; }

        public string DebitDescription { get; set; }

        public int ProductID { get; set; }

        public int DebitCreatedByID { get; set; }

        public DateTime DebitCreatedDate { get; set; }

        public int DebitModifiedByID { get; set; }

        public DateTime DebitModifiedDate { get; set; }

    }
}
