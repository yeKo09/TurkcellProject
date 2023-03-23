using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Unit
    {

        public int UnitID { get; set; }

        public string UnitName { get; set; }

        public override string ToString()
        {
            return UnitName;
        }

    }
}
