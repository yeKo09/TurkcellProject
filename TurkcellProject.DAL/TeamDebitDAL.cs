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
    public class TeamDebitDAL : IInsertRepo<TeamDebit>
    {
        public MyResult Insert(TeamDebit insertedData)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            object affectedTeamDebit = 0;

            SqlCommand cmd = myProvider.CreateCommand("insert into TeamDebit(TeamID, DebitID) values(@teamID, @debitID)");
            List<SqlParameter> mySqlParameters = new List<SqlParameter>();
            mySqlParameters.Add(new SqlParameter("@teamID", insertedData.TeamID));
            mySqlParameters.Add(new SqlParameter("@debitID", insertedData.DebitID));
            myProvider.AddParameters(mySqlParameters.ToArray(), cmd);

            affectedTeamDebit = myProvider.ExecuteScalar(cmd);

            myProvider.CloseConnection();

            return new MyResult()
            {
                Result = affectedTeamDebit,
                ResultMessage = affectedTeamDebit != null ? "Başarıyla oluşturuldu" : "Hata oluştu",
                ResultType = affectedTeamDebit != null
            };
        }
    }
}
