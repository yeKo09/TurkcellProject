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
    public class DebitDAL : ISelectSingleItemWithIDRepo<Debit>,IInsertRepo<Debit>
    {
        public MyResult Insert(Debit insertedData)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            int affectedDebitID = 0;


            SqlCommand cmd = myProvider.CreateCommand("insert into Debit(DebitReasonID, DebitTypeID, DebitStartDate, DebitEndDate, DebitDescription, DebitProductID, DebitCreatedBy, DebitCreatedDate) output INSERTED.DebitID values(@debitReasonID,@debitTypeID,@debitStartDate,@debitEndDate, @debitDescription, @debitProductID, @debitCreatedBy,@debitCreatedDate)");
            List<SqlParameter> mySqlParameters = new List<SqlParameter>();
            mySqlParameters.Add(new SqlParameter("@debitReasonID", insertedData.DebitReasonID));
            mySqlParameters.Add(new SqlParameter("@debitTypeID", insertedData.DebitTypeID));
            mySqlParameters.Add(new SqlParameter("@debitStartDate", insertedData.DebitStartDate));
            mySqlParameters.Add(new SqlParameter("@debitEndDate", insertedData.DebitEndDate));
            mySqlParameters.Add(new SqlParameter("@debitDescription", insertedData.DebitDescription));
            mySqlParameters.Add(new SqlParameter("@debitProductID", insertedData.ProductID));
            mySqlParameters.Add(new SqlParameter("@debitCreatedBy", insertedData.DebitCreatedByID));
            mySqlParameters.Add(new SqlParameter("@debitCreatedDate", insertedData.DebitCreatedDate));
            myProvider.AddParameters(mySqlParameters.ToArray(), cmd);

            affectedDebitID = (int)myProvider.ExecuteScalar(cmd);

            myProvider.CloseConnection();

            return new MyResult()
            {
                Result = affectedDebitID
                
            };
        }

        public Debit SelectSingleItem(int productID)
        {
            MSSQLProvider myProvider = new MSSQLProvider();
            myProvider.OpenConnection();

            SqlCommand cmd = myProvider.CreateCommand("select DebitID,DebitProductID from Debit d where d.DebitProductID = @productID");
            myProvider.AddOneParameter(new SqlParameter("@productID", productID), cmd);

            SqlDataReader reader = myProvider.ExecuteReader(cmd);

            Debit debit = null;
            if (reader.Read())
            {
                debit = new Debit();
                debit.DebitID = reader.GetInt32(0);
                debit.ProductID = reader.GetInt32(1);
            }

            myProvider.CloseConnection();
            return debit;
        }
    }
}
