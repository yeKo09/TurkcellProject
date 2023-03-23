using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class ProductWithBarcode
    {

        public int ProductWithBarcodeID { get; set; }

        public Guid Barcode { get; set; }

        public Product Product { get; set; }

    }
}
