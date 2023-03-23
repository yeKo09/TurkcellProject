using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class DebitReason
    {

        public int DebitReasonID { get; set; }

        public string DebitReasonName { get; set; }

        public override string ToString()
        {
            return DebitReasonName;
        }

    }
}
