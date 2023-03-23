using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Status
    {

        public int StatusID { get; set; }

        public string StatusName { get; set; }

        public override string ToString()
        {
            return StatusName;
        }

    }
}
