using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.DTO
{
    public class User
    {

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserPassword { get; set; }

        public string UserEmail { get; set; }

        public int? ManagerID { get; set; }

        public int UserRoleID { get; set; }

        public int UserTeamID { get; set; }

    }
}
