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
    public class CurrencyDAL : ISelectRepo<Currency>
    {
        public List<Currency> Select()
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select * from Currency");
            SqlDataReader reader = myProvider.ExecuteReader(cmd);
            List<Currency> currencies = new List<Currency>();

            Currency currency = null;
            while (reader.Read())
            {
                currency = new Currency();
                currency.CurrencyID = reader.GetInt32(0);
                currency.CurrencyName = reader.GetString(1);
                currencies.Add(currency);
            }

            myProvider.CloseConnection();
            return currencies;
        }
    }
}
