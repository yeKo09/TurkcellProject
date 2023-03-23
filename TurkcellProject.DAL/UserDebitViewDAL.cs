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
    public class UserDebitViewDAL : ISelectRepo<UserDebitView>
    {
        public List<UserDebitView> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select d.DebitID, dr.DebitReasonName, dt.DebitTypeName, u.userName, u.userSurname, m.ModelName, b.BrandName from UserDebit ud join Debit d on ud.DebitID = d.DebitID join DebitReason dr on d.DebitReasonID = dr.DebitReasonID join DebitType dt on d.DebitTypeID = dt.DebitTypeID join [User] u on u.UserID = ud.UserID join VProduct1 v on d.DebitProductID = v.ProductID join Model m on v.ProductModelID = m.ModelID join Brand b on b.BrandID = m.BrandID");

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            List<UserDebitView> userDebitViews = new List<UserDebitView>();

            UserDebitView userDebitView = null;
            while (reader.Read())
            {
                userDebitView = new UserDebitView();
                userDebitView.DebitViewUser = new DebitView()
                {
                    DebitID = reader.GetInt32(0),
                    DebitReasonName = reader.GetString(1),
                    DebitTypeName = reader.GetString(2),
                    ModelName = reader.GetString(5),
                    BrandName = reader.GetString(6)
                };
                userDebitView.DebitUserFullname = reader.GetString(3) + " " + reader.GetString(4);
                userDebitViews.Add(userDebitView);
            }

            myProvider.CloseConnection();
            return userDebitViews;
        }
    }
}
