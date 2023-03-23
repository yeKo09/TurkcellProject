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
    public class CurrentProductPriceDAL : ISelectSingleItemWithIDRepo<CurrentProductPrice>
    {
        public CurrentProductPrice SelectSingleItem(int productID)
        {
            MSSQLProvider myProvider = new MSSQLProvider();

            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select Top 1 * from CurrentProductPrice vf where vf.VProductID = @p order by CreatedDate desc");
            
            myProvider.AddOneParameter(new SqlParameter("@p", productID),cmd);

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            CurrentProductPrice currentProductPrice = null;
            if (reader.Read())
            {
                currentProductPrice = new CurrentProductPrice();
                currentProductPrice.CurrentProductPriceID = reader.GetInt32(0);
                currentProductPrice.CurrentProductMoney = reader.GetDecimal(1);
                currentProductPrice.CurrencyID = reader.GetInt32(2);
                currentProductPrice.ProductID = reader.GetInt32(3);
                currentProductPrice.CreatedDate = reader.GetDateTime(4);
            }

            myProvider.CloseConnection();
            return currentProductPrice;
        }
    }
}
