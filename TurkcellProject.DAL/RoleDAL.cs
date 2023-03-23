using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellProject.DTO;
using TurkcellProject.MyProvider;

namespace TurkcellProject.DAL
{
    public class RoleDAL
    {

        public Role GetRole(int roleID)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();
            SqlCommand cmd = myProvider.CreateCommand("select * from [Role] r where r.RoleID = @r");
            myProvider.AddOneParameter(new SqlParameter("@r", roleID),cmd);

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            Role role = null;
            if (reader.Read())
            {
                role = new Role();
                role.RoleID = reader.GetInt32(0);
                role.RoleName = reader.GetString(1);
            }

            myProvider.CloseConnection();
            return role;
        }

    }
}
