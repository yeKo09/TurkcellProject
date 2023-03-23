using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Brand
    {
        public int BrandID { get; set; }

        public string BrandName { get; set; }

        public override string ToString()
        {
            return BrandName;
        }
    }
}
