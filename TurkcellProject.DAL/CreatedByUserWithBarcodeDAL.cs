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
    public class CreatedByUserWithBarcodeDAL : ISelectWithIDRepo<ProductListView>
    {
        public List<ProductListView> SelectWithID(int userID)
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            myProvider.OpenConnection();
            SqlCommand cmd = myProvider.CreateCommand("select v.ProductID,bv.Barcode,vt.ProductTypeName,model.ModelName,b.BrandName,  (select Top 1 CurrentProductPrice from CurrentProductPrice vf where vf.VProductID = v.ProductID order by CreatedDate desc) as CurrentPrice from VProduct1 v join ProductWithBarcode bv on v.ProductID = bv.VProductID join ProductType vt on vt.ProductTypeID = v.ProductTypeID join Model model on model.ModelID = v.ProductModelID join Brand b on b.BrandID = model.BrandID where v.ProductCreatedBy = @pcb");
            myProvider.AddOneParameter(new SqlParameter("@pcb", userID), cmd);

            List<ProductListView> products = new List<ProductListView>();

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            ProductListView productListView = null;
            while (reader.Read())
            {
                productListView = new ProductListView();
                productListView.ProductID = reader.GetInt32(0);
                Guid guidValue = reader.GetGuid(reader.GetOrdinal("Barcode"));
                productListView.Barcode = guidValue;
                productListView.ProductTypeName = reader.GetString(2);
                productListView.ModelName = reader.GetString(3);
                productListView.BrandName = reader.GetString(4);
                productListView.CurrentPrice = reader.GetDecimal(5);
                products.Add(productListView);
            }

            myProvider.CloseConnection();
            return products;
        }
    }
}
