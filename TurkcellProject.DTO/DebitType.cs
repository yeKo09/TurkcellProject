using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class DebitType
    {

        public int DebitTypeID { get; set; }

        public string DebitTypeName { get; set; }

        public override string ToString()
        {
            return DebitTypeName;
        }

    }
}
