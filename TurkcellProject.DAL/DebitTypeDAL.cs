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
    public class DebitTypeDAL : ISelectRepo<DebitType>
    {
        public List<DebitType> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from DebitType");

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            List<DebitType> debitTypes = new List<DebitType>();

            DebitType debitType = null;
            while(reader.Read())
            {
                debitType = new DebitType();
                debitType.DebitTypeID = reader.GetInt32(0);
                debitType.DebitTypeName = reader.GetString(1);
                debitTypes.Add(debitType);
            }

            myProvider.CloseConnection();
            return debitTypes;
        }
    }
}
