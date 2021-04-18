using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace studentInternship
{
    public class Company
    {
        public int companyPK { get; private set; }
        public string companyName { get; private set; }
        public string companyAddress { get; private set; }
        public int companyNo { get; private set; }


        public int getCompanyPK(int companyNo)
        {
            string query = "select companyPK from Companies where companyNo=@companyNo";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@companyNo", companyNo);
            DataAccessLayer dal = new DataAccessLayer();
            if (dal.connectionOpen())
            {
                SqlDataReader reader = dal.returnReader(sqlCommand);
                if (reader.HasRows)
                {
                    reader.Read();
                    this.companyPK=Convert.ToInt32(reader[0].ToString());
                    reader.Close();
                    dal.connectionClose();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            else
            {
                return -2;
            }
        }

        public int getCompanyPersonalDetails(int companyNo)
        {
            string query = "select companyPK, companyName, companyAddress, companyNo from Companies where companyNo = @companyNo";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@companyNo", companyNo);
            DataAccessLayer dal = new DataAccessLayer();
            if (dal.connectionOpen())
            {
                SqlDataReader reader = dal.returnReader(sqlCommand);
                if (reader.HasRows)
                {
                    reader.Read();
                    this.companyPK = Convert.ToInt32(reader[0].ToString());
                    this.companyName = reader[1].ToString();
                    this.companyAddress= reader[2].ToString();
                    this.companyNo = Convert.ToInt32(reader[3].ToString());
                    reader.Close();
                    dal.connectionClose();
                    return 1;

                }
                else
                { return -1; }
            }
            else
            { return -2; }
        }

        public string insertNewCompany()
        {
            string query = "insert into Companies values(@cName, @cAddress, @companyNo);";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@cName", this.companyName);
            sqlCommand.Parameters.AddWithValue("@cAddress", this.companyAddress);
            sqlCommand.Parameters.AddWithValue("@companyNo", this.companyNo);
            DataAccessLayer dal = new DataAccessLayer();

            try
            {
                dal.connectionOpen();
                if (getCompanyPK(this.companyNo) == -1)
                {
                    dal.queryExecution(sqlCommand);
                    dal.connectionClose();
                    return "Congrats! New company is inserted";
                }
                else
                {
                    dal.connectionClose();
                    return "The company with this NIP " + this.companyNo.ToString() +
                        "  is already exist in our Database";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void setCompanyProperties(string cName, string cAddress, int companyNo)

        {
            this.companyPK = 0;
            this.companyName = cName;
            this.companyAddress=cAddress;
            this.companyNo = companyNo;
        }
        public void resetCompanyProperties()
        {
            this.companyPK = 0;
            this.companyName = "";
            this.companyAddress = "";
            this.companyNo = 0; 
           

        }

    }
}
