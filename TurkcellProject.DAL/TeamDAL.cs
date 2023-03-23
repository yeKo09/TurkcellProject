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
    public class TeamDAL : ISelectSingleItemWithIDRepo<Team>
    {
        public Team SelectSingleItem(int teamID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();

            SqlCommand cmd = myProvider2.CreateCommand("select * from Team t where t.TeamID = @teamID");
            myProvider2.AddOneParameter(new SqlParameter("@u", teamID), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            Team team = null;
            if (reader.Read())
            {
                team = new Team();
                team.TeamID = reader.GetInt32(0);
                team.TeamName = reader.GetString(1);
                team.TeamCompanyID = reader.GetInt32(2);
            }

            myProvider2.CloseConnection();
            return team;
        }
    }
}
