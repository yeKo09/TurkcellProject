using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class Model
    {

        public int ModelID { get; set; }

        public string ModelName { get; set; }

        public int ModelBrandID { get; set; }

        public override string ToString()
        {
            return ModelName;
        }

    }
}
