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
    public class UserDAL : ISelectSingleItemWithIDRepo<User>
    {
        public User SelectSingleItem(int userID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();

            SqlCommand cmd = myProvider2.CreateCommand("select UserID from [User] u where u.UserID = @userID");
            myProvider2.AddOneParameter(new SqlParameter("@userID", userID), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            User user = null;
            if (reader.Read())
            {
                user = new User();
                user.UserID = reader.GetInt32(0);
                
            }

            myProvider2.CloseConnection();
            return user;
        }
    }
}
