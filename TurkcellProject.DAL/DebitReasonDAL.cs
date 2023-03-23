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
    public class DebitReasonDAL : ISelectRepo<DebitReason>
    {
        public List<DebitReason> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from DebitReason");

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            List<DebitReason> debitReasons = new List<DebitReason>();

            DebitReason debitReason = null;
            while(reader.Read())
            {
                debitReason = new DebitReason();
                debitReason.DebitReasonID = reader.GetInt32(0);
                debitReason.DebitReasonName = reader.GetString(1);
                debitReasons.Add(debitReason);
            }

            myProvider.CloseConnection();
            return debitReasons;
        }
    }
}
