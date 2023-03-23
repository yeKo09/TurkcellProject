using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellProject.DAL.IRepos;
using TurkcellProject.DTO;
using TurkcellProject.MyProvider;

namespace TurkcellProject.DAL
{
    public class UserLoginDAL
    {
        public User Login(string email, string password)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from [User] u where u.UserEmail = @ue and u.UserPassword = @up");

            List<SqlParameter> mySqlParameters = new List<SqlParameter>();
            mySqlParameters.Add(new SqlParameter("@ue", email));
            mySqlParameters.Add(new SqlParameter("@up", password));
            myProvider.AddParameters(mySqlParameters.ToArray(), cmd);
            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            User user = null;

            if (reader.Read())
            {
                user = new User();
                user.UserID = reader.GetInt32(0);
                user.UserName = reader.GetString(1);
                user.UserSurname = reader.GetString(2);
                user.UserPassword = reader.GetString(3);
                user.UserEmail = reader.GetString(4);
                if (reader.IsDBNull(5))
                {
                    user.ManagerID = null;
                }
                else
                {
                    user.ManagerID = reader.GetInt32(5);
                }
                user.UserRoleID = reader.GetInt32(6);
                user.UserTeamID = reader.GetInt32(7);
            }

            myProvider.CloseConnection();
            return user;

        }
    }
}
