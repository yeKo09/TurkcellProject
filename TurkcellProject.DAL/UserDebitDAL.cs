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
    public class UserDebitDAL : IInsertRepo<UserDebit>
    {
        public MyResult Insert(UserDebit insertedData)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            object affectedUserDebit = 0;

            SqlCommand cmd = myProvider.CreateCommand("insert into UserDebit(UserID, DebitID) values(@userID, @debitID)");
            List<SqlParameter> mySqlParameters = new List<SqlParameter>();
            mySqlParameters.Add(new SqlParameter("@userID", insertedData.UserID));
            mySqlParameters.Add(new SqlParameter("@debitID", insertedData.DebitID));
            myProvider.AddParameters(mySqlParameters.ToArray(), cmd);

            affectedUserDebit = myProvider.ExecuteScalar(cmd);

            myProvider.CloseConnection();

            return new MyResult()
            {
                Result = affectedUserDebit,
                ResultMessage = affectedUserDebit != null ? "Başarıyla oluşturuldu" : "Hata oluştu",
                ResultType = affectedUserDebit != null
            };
        }
    }
}
