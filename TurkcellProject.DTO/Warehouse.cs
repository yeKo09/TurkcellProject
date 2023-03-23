using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Warehouse
    {

        public int WarehouseID { get; set; }

        public string WarehouseName { get; set; }

        public Company WarehouseCompany { get; set; }

    }
}
