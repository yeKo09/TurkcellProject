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
    public class ProductStatusDAL : ISelectSingleItemWithIDRepo<ProductStatus>, IUpdateRepo<ProductStatus>
    {
        public ProductStatus SelectSingleItem(int productID)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from ProductStatus ps where ps.VProductID = @productID");
            myProvider.AddOneParameter(new SqlParameter("@productID", productID), cmd);

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            ProductStatus productStatus = null;
            if (reader.Read())
            {
                productStatus = new ProductStatus();
                productStatus.ProductStatusID = reader.GetInt32(0);
                productStatus.ProductID = reader.GetInt32(1);
                productStatus.StatusID = reader.GetInt32(2);
            }

            myProvider.CloseConnection();
            return productStatus;
        }

        public MyResult Update(ProductStatus updatedData)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();

            int affectedProductStatusRows = 0;

            myProvider2.OpenConnection();

            SqlCommand cmd2 = myProvider2.CreateCommand("update ProductStatus set StatusID = @status where VProductID = @productID");
            List<SqlParameter> mySqlParameters = new List<SqlParameter>();
            mySqlParameters.Add(new SqlParameter("@status", updatedData.StatusID));
            mySqlParameters.Add(new SqlParameter("@productID", updatedData.ProductID));
            myProvider2.AddParameters(mySqlParameters.ToArray(), cmd2);

            affectedProductStatusRows = myProvider2.ExecuteNon(cmd2);

            myProvider2.CloseConnection();

            return new MyResult()
            {
                ResultMessage = affectedProductStatusRows > 0 ? "Durum başarıyla değiştirildi." : "Hata oluştu",
                ResultType = affectedProductStatusRows > 0
            };
        }
    }
}
