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
    public class StatusDAL : ISelectRepo<Status>, ISelectSingleItemWithIDRepo<Status>
    {
        public List<Status> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from Status");
            SqlDataReader reader = myProvider.ExecuteReader(cmd);
            List<Status> statusList = new List<Status>();

            Status status = null;
            while (reader.Read())
            {
                status = new Status();
                status.StatusID = reader.GetInt32(0);
                status.StatusName = reader.GetString(1);
                statusList.Add(status);
            }

            myProvider.CloseConnection();
            return statusList;
        }

        public Status SelectSingleItem(int statusID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();

            SqlCommand cmd = myProvider2.CreateCommand("select * from Status s where s.StatusID = @statusID");
            myProvider2.AddOneParameter(new SqlParameter("@statusID", statusID), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            Status status = null;
            if (reader.Read())
            {
                status = new Status();
                status.StatusID = reader.GetInt32(0);
                status.StatusName = reader.GetString(1); 
            }

            myProvider2.CloseConnection();
            return status;
        }
    }
}
