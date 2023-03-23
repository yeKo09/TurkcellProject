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
    public class ProductWithoutBarcodeDAL : ISelectSingleItemWithIDRepo<ProductWithoutBarcode>
    {
        public ProductWithoutBarcode SelectSingleItem(int productID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();
            SqlCommand cmd = myProvider2.CreateCommand("select * from ProductWithoutBarcode pwob where pwob.VProductID = @p");
            myProvider2.AddOneParameter(new SqlParameter("@p", productID), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            ProductWithoutBarcode productWithoutBarcode = null;
            while (reader.Read())
            {
                productWithoutBarcode = new ProductWithoutBarcode();
                productWithoutBarcode.ProductWithoutBarcodeID = reader.GetInt32(0);
                productWithoutBarcode.Count = reader.GetInt16(1);
                productWithoutBarcode.UnitID = reader.GetInt32(2);
                productWithoutBarcode.ProductID = reader.GetInt32(3);
            }
            myProvider2.CloseConnection();
            return productWithoutBarcode;
        }
    }
}
