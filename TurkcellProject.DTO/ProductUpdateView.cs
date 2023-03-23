using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class ProductUpdateView
    {

        public Product TheProduct { get; set; }

        public bool IsWithBarcode { get; set; }

        public ProductWithBarcode BarcodedProduct { get; set; }

        public ProductWithoutBarcode NonBarcodedProduct { get; set; }

        public CurrentProductPrice ProductCurrentPrice { get; set; }

        public bool IsCurrentPriceChanged { get; set; }

        public int UserID { get; set; }

    }
}
