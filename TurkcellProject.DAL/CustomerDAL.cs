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
    public class CustomerDAL : ISelectSingleItemWithIDRepo<Customer>
    {
        public Customer SelectSingleItem(int customerSubNo)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();

            SqlCommand cmd = myProvider2.CreateCommand("select CustomerID,CustomerSubNo from Customer c where c.CustomerSubNo = @customerSubNo");
            myProvider2.AddOneParameter(new SqlParameter("@customerSubNo", customerSubNo), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            Customer customer = null;
            if (reader.Read())
            {
                customer = new Customer();
                customer.CustomerID = reader.GetInt32(0);
                customer.CustomerSubNo = reader.GetString(1);
            }

            myProvider2.CloseConnection();
            return customer;
        }
    }
}
