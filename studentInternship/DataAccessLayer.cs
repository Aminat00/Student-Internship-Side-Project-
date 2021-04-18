using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //added
using System.Data;           //added
using System.Configuration;  //added

namespace studentInternship
{
    public class DataAccessLayer
    {
        SqlConnection sqlConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnectionString"].ConnectionString);

        public DataTable selectData(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = sqlConnection;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public SqlDataReader returnReader(SqlCommand sqlCommand)
        {   
            //need open connection
            sqlCommand.Connection = sqlConnection;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }
        public void queryExecution(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
        }

        public int returnValue(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = sqlConnection;
            try
            {
                int PK = (int)sqlCommand.ExecuteScalar();
                return PK;
            }
            catch
            {
                return -1;
            }
        }
        public bool connectionOpen()
        {
            try
            {
                sqlConnection.Open();
                return true;

            }
            catch
            {

                return false;
            }
        }
        public bool connectionClose()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
