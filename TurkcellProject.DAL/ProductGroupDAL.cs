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
    public class ProductGroupDAL : ISelectRepo<ProductGroup>
    {
        public List<ProductGroup> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from ProductGroup");
            SqlDataReader reader = myProvider.ExecuteReader(cmd);
            List<ProductGroup> productGroups = new List<ProductGroup>();

            ProductGroup productGroup = null;
            while (reader.Read())
            {
                productGroup = new ProductGroup();
                productGroup.ProductGroupID = reader.GetInt32(0);
                productGroup.ProductGroupName = reader.GetString(1);
                productGroups.Add(productGroup);
            }

            myProvider.CloseConnection();
            return productGroups;
        }
    }
}
