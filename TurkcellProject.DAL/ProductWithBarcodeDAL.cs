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
    public class ProductWithBarcodeDAL : ISelectRepo<ProductListView>, ISelectSingleItemWithIDRepo<ProductWithBarcode>
    {
        public List<ProductListView> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            myProvider.OpenConnection();
            List<ProductListView> products = new List<ProductListView>();
            SqlCommand cmd = myProvider.CreateCommand("select v.ProductID,bv.Barcode,vt.ProductTypeName,model.ModelName,b.BrandName, (select Top 1 CurrentProductPrice from CurrentProductPrice vf where vf.VProductID = v.ProductID order by CreatedDate desc ) as CurrentPrice from VProduct1 v join ProductWithBarcode bv on v.ProductID = bv.VProductID join ProductType vt on vt.ProductTypeID = v.ProductTypeID join Model model on model.ModelID = v.ProductModelID join Brand b on b.BrandID = model.BrandID");

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

        public ProductWithBarcode SelectSingleItem(int productID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();
            SqlCommand cmd = myProvider2.CreateCommand("select * from ProductWithBarcode pwb where pwb.VProductID = @p");
            myProvider2.AddOneParameter(new SqlParameter("@p", productID), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            ProductWithBarcode productWithBarcode = null;
            while (reader.Read())
            {
                productWithBarcode = new ProductWithBarcode();
                Guid guidValue = reader.GetGuid(reader.GetOrdinal("Barcode"));
                productWithBarcode.Barcode = guidValue;
            }
            myProvider2.CloseConnection();
            return productWithBarcode;
        }
    }
}
