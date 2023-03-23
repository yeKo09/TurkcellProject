using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class ProductWarehouse
    {

        public int ProductWarehouseID { get; set; }

        public Product ProductID { get; set; }

        public Warehouse WarehouseID { get; set; }

        public string Description { get; set; }

    }
}
