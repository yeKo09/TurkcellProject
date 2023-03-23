using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Currency
    {

        public int CurrencyID { get; set; }

        public string CurrencyName { get; set; }

        public override string ToString()
        {
            return CurrencyName;
        }
    }
}
