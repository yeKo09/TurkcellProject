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
    public class ModelDAL : ISelectRepo<Model>, ISelectSingleItemWithIDRepo<Model>, ISelectWithIDRepo<Model>
    {
        public List<Model> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from Model");
            SqlDataReader reader = myProvider.ExecuteReader(cmd);
            List<Model> models = new List<Model>();

            Model model = null;
            while (reader.Read())
            {
                model = new Model();
                model.ModelID = reader.GetInt32(0);
                model.ModelName = reader.GetString(1);
                model.ModelBrandID = reader.GetInt32(2);
                models.Add(model);
            }

            myProvider.CloseConnection();
            return models;
        }

        public Model SelectSingleItem(int modelID)
        {
            MSSQLProvider myProvider2 = new MSSQLProvider();

            myProvider2.OpenConnection();
            SqlCommand cmd = myProvider2.CreateCommand("select * from Model m where m.ModelID = @m");
            myProvider2.AddOneParameter(new SqlParameter("@m", modelID),cmd);
            SqlDataReader reader = myProvider2.ExecuteReader(cmd);

            Model model = null;
            if (reader.Read())
            {
                model = new Model();
                model.ModelID = reader.GetInt32(0);
                model.ModelName = reader.GetString(1);
                model.ModelBrandID = reader.GetInt32(2);
            }

            myProvider2.CloseConnection();
            return model;
        }

        public List<Model> SelectWithID(int brandID)
        {
            MSSQLProvider myProvider3 = new MSSQLProvider();
            myProvider3.OpenConnection();

            SqlCommand cmd = myProvider3.CreateCommand("select * from Model m where m.BrandID = @brandID");
            myProvider3.AddOneParameter(new SqlParameter("@brandID", brandID), cmd);

            SqlDataReader reader = myProvider3.ExecuteReader(cmd);

            List<Model> models = new List<Model>();

            Model model = null;
            while (reader.Read())
            {
                model = new Model();
                model.ModelID = reader.GetInt32(0);
                model.ModelName = reader.GetString(1);
                model.ModelBrandID = reader.GetInt32(2);
                models.Add(model);
            }

            myProvider3.CloseConnection();
            return models;
        }
    }
}
