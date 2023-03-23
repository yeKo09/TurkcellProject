using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellProject.MyProvider
{
    public class MSSQLProvider
    {
        SqlConnection conn = null;
        SqlTransaction transaction = null;
        SqlConnectionStringBuilder bl = null;

        public MSSQLProvider()
        {
            bl = new SqlConnectionStringBuilder();
            bl.DataSource = ".";
            bl.IntegratedSecurity = true;
            bl.InitialCatalog = "VarlikDB";
            conn = new SqlConnection(bl.ConnectionString);
           
            
        }


        public SqlCommand CreateCommand(string wantedQuery)
        {
            SqlCommand cmd = null;
            cmd = new SqlCommand();
            cmd.CommandText = wantedQuery;
            cmd.Connection = conn;
            return cmd;
        }

        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }
        public void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

        }


        public int ExecuteNon(SqlCommand cmd)
        {
            int result = 0;

            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                result = 0;
            }
            

            return result;



        }

        public void StartTheTransaction()
        {
            transaction = conn.BeginTransaction();
        }

        public SqlCommand AddTransactionToCommand(SqlCommand cmd)
        {
            cmd.Transaction = transaction;
            return cmd;
        }

        public void CommitTransaction()
        {
            transaction.Commit();
        }


        public void RollbackTransaction()
        {
            transaction.Rollback();
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            object result = null;

            try
            {
               
                result = cmd.ExecuteScalar();
            }
            catch (Exception)
            {

            }
            

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(SqlCommand cmd)//yukardakiyle aynı yukarda sadece try cach var
        {
            SqlDataReader rdr = null;
            try
            {
               
                rdr = cmd.ExecuteReader();
            }
            catch (Exception)
            {


            }
            

            return rdr;

        }
        public void AddOneParameter(SqlParameter sqlParameter, SqlCommand cmd)
        {
            cmd.Parameters.Add(sqlParameter);
        }

        public void AddParameters(SqlParameter[] sqlParameters, SqlCommand cmd)
        {
            //cmd.Parameters.AddWithValue("GirilenKargo", Kargo);
            cmd.Parameters.AddRange(sqlParameters);

        }

    }
}

