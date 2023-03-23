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
    public class CustomerProductDAL : IInsertRepo<CustomerProduct>
    {
        public MyResult Insert(CustomerProduct insertedData)
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            int affectedCustomerProductRows = 0;
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("insert into CustomerProduct(CustomerID, VProductID, CreatedDate,  [Description]) values(@customerID, @productID, @createdDate, @description)");
            List<SqlParameter> mySqlParameters = new List<SqlParameter>();
            mySqlParameters.Add(new SqlParameter("@customerID", insertedData.CustomerID));
            mySqlParameters.Add(new SqlParameter("@productID", insertedData.ProductID));
            mySqlParameters.Add(new SqlParameter("@createdDate", insertedData.CreatedDate));
            mySqlParameters.Add(new SqlParameter("@description", insertedData.CustomerProductDescription));
            myProvider.AddParameters(mySqlParameters.ToArray(), cmd);

            affectedCustomerProductRows = myProvider.ExecuteNon(cmd);

            myProvider.CloseConnection();
            return new MyResult()
            {
                Result = affectedCustomerProductRows,
                ResultMessage = affectedCustomerProductRows > 0 ? "Başarılı" : "Hata oluştu",
                ResultType = affectedCustomerProductRows > 0
            };
        }
    }
}
