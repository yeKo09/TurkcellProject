using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class CurrentProductPrice
    {

        public int CurrentProductPriceID { get; set; }

        public decimal CurrentProductMoney { get; set; }

        public int CurrencyID { get; set; }

        public int ProductID { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
