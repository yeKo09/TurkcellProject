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
    public class UnitDAL : ISelectRepo<Unit>, ISelectSingleItemWithIDRepo<Unit>
    {
        public List<Unit> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from Unit");
            SqlDataReader reader = myProvider.ExecuteReader(cmd);
            List<Unit> units = new List<Unit>();

            Unit unit = null;
            while (reader.Read())
            {
                unit = new Unit();
                unit.UnitID = reader.GetInt32(0);
                unit.UnitName = reader.GetString(1);
                units.Add(unit);
            }

            myProvider.CloseConnection();
            return units;
        }

        public Unit SelectSingleItem(int unitID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();

            SqlCommand cmd = myProvider2.CreateCommand("select * from Unit u where u.UnitID = @u");
            myProvider2.AddOneParameter(new SqlParameter("@u", unitID), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            Unit unit = null;
            if (reader.Read())
            {
                unit = new Unit();
                unit.UnitID = reader.GetInt32(0);
                unit.UnitName = reader.GetString(1);
            }

            myProvider2.CloseConnection();
            return unit;
        }
    }
}
