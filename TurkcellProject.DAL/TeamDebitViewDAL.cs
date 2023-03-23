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
    public class TeamDebitViewDAL : ISelectRepo<TeamDebitView>
    {
        public List<TeamDebitView> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select d.DebitID, dr.DebitReasonName, dt.DebitTypeName, t.TeamName, m.ModelName, b.BrandName from TeamDebit td join Debit d on td.DebitID = d.DebitID join DebitReason dr on d.DebitReasonID = dr.DebitReasonID join DebitType dt on d.DebitTypeID = dt.DebitTypeID join Team t on t.TeamID = td.TeamID join VProduct1 v on d.DebitProductID = v.ProductID join Model m on v.ProductModelID = m.ModelID join Brand b on b.BrandID = m.BrandID");

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            List<TeamDebitView> teamDebitViews = new List<TeamDebitView>();

            TeamDebitView teamDebitView = null;
            while (reader.Read())
            {
                teamDebitView = new TeamDebitView();
                teamDebitView.DebitViewTeam = new DebitView()
                {
                    DebitID = reader.GetInt32(0),
                    DebitReasonName = reader.GetString(1),
                    DebitTypeName = reader.GetString(2),
                    ModelName = reader.GetString(4),
                    BrandName = reader.GetString(5)
                };
                teamDebitView.TeamName = reader.GetString(3);
                teamDebitViews.Add(teamDebitView);
            }

            myProvider.CloseConnection();
            return teamDebitViews;
        }
    }
}
