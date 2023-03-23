using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class ProductListView
    {
        public int ProductID { get; set; }

        public Guid Barcode { get; set; }

        public string ProductTypeName { get; set; }

        public string ModelName { get; set; }

        public string BrandName { get; set; }

        public decimal CurrentPrice { get; set; }
    }
}
