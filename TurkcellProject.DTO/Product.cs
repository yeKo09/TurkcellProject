using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Product
    {

        public int ProductID { get; set; }

        public int ProductTypeID { get; set; }

        public int ProductModelID { get; set; }

        public bool IsProductGuarenteed { get; set; }

        public string ProductDescription { get; set; }

        public DateTime ProductEntryDate { get; set; }

        public DateTime? ProductRetireDate { get; set; }

        public decimal ProductCost { get; set; }

        public int ProductCurrencyID { get; set; }

        public string ProductFilePath { get; set; }

        public int ProductCreatedByID { get; set; }

        public DateTime ProductCreatedDate { get; set; }

        public int? ProductModifiedByID { get; set; }

        public DateTime? ProductModifiedDate { get; set; }

        public int ProductGroupID { get; set; }



    }
}
