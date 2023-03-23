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
    public class ProductWarehouseDAL : IDeleteRepo<ProductWarehouse>
    {
        public MyResult Delete(int productID)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            int affectedDeletedRows = 0;

            SqlCommand cmd = myProvider.CreateCommand("delete from ProductWarehouse where VProductID = @productID");
            myProvider.AddOneParameter(new SqlParameter("@productID", productID), cmd);

            affectedDeletedRows = myProvider.ExecuteNon(cmd);

            myProvider.CloseConnection();

            return new MyResult()
            {
                ResultMessage = affectedDeletedRows > 0 ? "Başarıyla silindi" : "Hata oluştu",
                ResultType = affectedDeletedRows > 0
            };
        }
    }
}
