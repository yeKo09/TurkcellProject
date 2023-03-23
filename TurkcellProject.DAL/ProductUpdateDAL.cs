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
    public class ProductUpdateDAL : ISelectSingleItemWithIDRepo<ProductUpdateView>, IUpdateRepo<ProductUpdateView>
    {
        public ProductUpdateView SelectSingleItem(int productID)
        {
            MSSQLProvider myProvider3 = new MSSQLProvider();
            myProvider3.OpenConnection();
            SqlCommand cmd = myProvider3.CreateCommand("select * from VProduct1 v where v.ProductID = @p");
            myProvider3.AddOneParameter(new SqlParameter("@p", productID), cmd);
            SqlDataReader reader = myProvider3.ExecuteReader(cmd);

            ProductUpdateView productUpdateView = null;
            Product product = null;

            if (reader.Read())
            {
                product = new Product();
                product.ProductID = reader.GetInt32(0);
                product.ProductTypeID = reader.GetInt32(1);
                product.ProductModelID = reader.GetInt32(2);
                product.IsProductGuarenteed = reader.GetBoolean(3);
                product.ProductDescription = reader.GetString(4);
                product.ProductEntryDate = reader.GetDateTime(5);
                if (reader.IsDBNull(6))
                {
                    product.ProductRetireDate = null;
                }
                else
                {
                    product.ProductRetireDate = reader.GetDateTime(6);
                }
                product.ProductCost = reader.GetDecimal(7);
                product.ProductCurrencyID = reader.GetInt32(8);
                //filepath 9 
                product.ProductCreatedByID = reader.GetInt32(10);
                product.ProductCreatedDate = reader.GetDateTime(11);
                if (reader.IsDBNull(12))
                {
                    product.ProductModifiedByID = null;
                }
                else
                {
                    product.ProductModifiedByID = reader.GetInt32(12);
                }
                if (reader.IsDBNull(13))
                {
                    product.ProductModifiedDate = null;
                }
                else
                {
                    product.ProductModifiedDate = reader.GetDateTime(13);
                }
                product.ProductGroupID = reader.GetInt32(14);
                productUpdateView = new ProductUpdateView();
                productUpdateView.TheProduct = product;
            }

            myProvider3.CloseConnection();
            return productUpdateView;
        }

        public MyResult Update(ProductUpdateView updatedData)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            int affectedUpdateProductRows = 0;
            int affectedBarcodeProductRows = 0;
            int affectedCurrentProductPriceRows = 0;
            try
            {
                myProvider.OpenConnection();
                myProvider.StartTheTransaction();
                SqlCommand cmd1 = myProvider.CreateCommand("update VProduct1 set ProductModelID = @productModelID, IsProductGuarenteed = @isProductGuarenteed, ProductDescription = @productDescription, ProductEntryDate = @productEntryDate, ProductCost = @productCost, ProductCurrency = @productCurrency, ProductModifiedBy = @productModifiedBy, ProductModifiedDate = GETDATE(), ProductGroupID = @productGroupID where ProductID = @productID");
                List<SqlParameter> mySqlParameters = new List<SqlParameter>();
                mySqlParameters.Add(new SqlParameter(("@productModelID"), updatedData.TheProduct.ProductModelID));
                mySqlParameters.Add(new SqlParameter(("@isProductGuarenteed"), updatedData.TheProduct.IsProductGuarenteed));
                mySqlParameters.Add(new SqlParameter(("@productDescription"), updatedData.TheProduct.ProductDescription));
                mySqlParameters.Add(new SqlParameter(("@productEntryDate"), updatedData.TheProduct.ProductEntryDate));
                mySqlParameters.Add(new SqlParameter(("@productCost"), updatedData.TheProduct.ProductCost));
                mySqlParameters.Add(new SqlParameter(("@productCurrency"), updatedData.TheProduct.ProductCurrencyID));
                mySqlParameters.Add(new SqlParameter(("@productModifiedBy"), updatedData.UserID)); //formloginden gelen kullanıcı
                mySqlParameters.Add(new SqlParameter(("@productGroupID"), updatedData.TheProduct.ProductGroupID));
                mySqlParameters.Add(new SqlParameter("@productID", updatedData.TheProduct.ProductID));
                myProvider.AddParameters(mySqlParameters.ToArray(), cmd1);
                myProvider.AddTransactionToCommand(cmd1);

                SqlCommand cmd2;
                if (updatedData.IsWithBarcode)
                {
                    cmd2 = myProvider.CreateCommand("update ProductWithBarcode set Barcode = @barcode where VProductID = @productID");
                    List<SqlParameter> myThirdSqlParameters = new List<SqlParameter>();
                    myThirdSqlParameters.Add(new SqlParameter("@barcode", updatedData.BarcodedProduct.Barcode));
                    myThirdSqlParameters.Add(new SqlParameter("@productID", updatedData.TheProduct.ProductID));
                    myProvider.AddParameters(myThirdSqlParameters.ToArray(), cmd2);
                }
                else
                {
                    cmd2 = myProvider.CreateCommand("update ProductWithoutBarcode set PWOBCount = @pwobCount, PWOBUnitID = @pwobUnitID where VProductID = @productID");
                    List<SqlParameter> mySecondSqlParameters = new List<SqlParameter>();
                    mySecondSqlParameters.Add(new SqlParameter("@pwobCount", updatedData.NonBarcodedProduct.Count));
                    mySecondSqlParameters.Add(new SqlParameter("@pwobUnitID", updatedData.NonBarcodedProduct.UnitID));
                    mySecondSqlParameters.Add(new SqlParameter("@productID", updatedData.TheProduct.ProductID));
                    myProvider.AddParameters(mySecondSqlParameters.ToArray(), cmd2);
                }

                myProvider.AddTransactionToCommand(cmd2);

                SqlCommand cmd3 = myProvider.CreateCommand("update CurrentProductPrice set CurrentProductPrice = @currentProductPrice, CurrentProductCurrency = @currentProductCurrencyID, CreatedDate = @createdDate where VProductID = @productID");

                List<SqlParameter> myFourthSqlParameters = new List<SqlParameter>();
                myFourthSqlParameters.Add(new SqlParameter("@currentProductPrice", updatedData.ProductCurrentPrice.CurrentProductMoney));
                myFourthSqlParameters.Add(new SqlParameter("@currentProductCurrencyID", updatedData.ProductCurrentPrice.CurrencyID));
                myFourthSqlParameters.Add(new SqlParameter("@productID", updatedData.ProductCurrentPrice.ProductID));
                myFourthSqlParameters.Add(new SqlParameter("@createdDate", updatedData.ProductCurrentPrice.CreatedDate));
                

                myProvider.AddParameters(myFourthSqlParameters.ToArray(), cmd3);
                myProvider.AddTransactionToCommand(cmd3);


                affectedUpdateProductRows = myProvider.ExecuteNon(cmd1);
                affectedBarcodeProductRows = myProvider.ExecuteNon(cmd2);
                affectedCurrentProductPriceRows = myProvider.ExecuteNon(cmd3);
                myProvider.CommitTransaction();

            }
            catch (Exception)
            {
                myProvider.RollbackTransaction();
            }
            finally
            {
                myProvider.CloseConnection();
            }


            return new MyResult()
            {
                Result = affectedUpdateProductRows,
                ResultMessage = (affectedUpdateProductRows > 0 && affectedCurrentProductPriceRows > 0
                && affectedBarcodeProductRows > 0) ? "Varlık başarıyla güncellendi" : "Hata oluştu.",
                ResultType = affectedUpdateProductRows > 0 && affectedCurrentProductPriceRows > 0
                && affectedBarcodeProductRows > 0
            };

        }
    }
}
