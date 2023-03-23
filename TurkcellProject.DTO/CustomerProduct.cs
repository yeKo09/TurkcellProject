using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class CustomerProduct
    {

        public int CustomerProductID { get; set; }

        public int CustomerID { get; set; }

        public int ProductID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CustomerProductDescription { get; set; }

    }
}
