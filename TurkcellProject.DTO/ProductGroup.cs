using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class ProductGroup
    {

        public int ProductGroupID { get; set; }

        public string ProductGroupName { get; set; }

        public override string ToString()
        {
            return ProductGroupName;
        }

    }
}
