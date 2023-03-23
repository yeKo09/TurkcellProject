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
    public class BrandDAL : ISelectRepo<Brand>, ISelectSingleItemWithIDRepo<Brand>
    {
        public List<Brand> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from Brand");
            SqlDataReader reader = myProvider.ExecuteReader(cmd);
            List<Brand> brands = new List<Brand>();

            Brand brand = null;
            while (reader.Read())
            {
                brand = new Brand();
                brand.BrandID = reader.GetInt32(0);
                brand.BrandName = reader.GetString(1);
                brands.Add(brand);
            }

            myProvider.CloseConnection();
            return brands;
        }

        public Brand SelectSingleItem(int brandID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();
            myProvider2.OpenConnection();

            SqlCommand cmd = myProvider2.CreateCommand("select * from Brand b where b.BrandID = @b");
            myProvider2.AddOneParameter(new SqlParameter("@b", brandID), cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            Brand brand = null;
            if (reader.Read())
            {
                brand = new Brand();
                brand.BrandID = reader.GetInt32(0);
                brand.BrandName = reader.GetString(1);
            }

            myProvider2.CloseConnection();
            return brand;
        }
    }
}
