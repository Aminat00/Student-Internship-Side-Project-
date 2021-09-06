using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data;

namespace studentInternship
{
    public class Student2
    {
        public int studentPK { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public int studentNo { get; private set; }
        public string faculty { get; private set; }

        public int getStudentPK(int student_no)
        {
            int result = -2;
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "getStudentPK";//name of the stored procedure
            sqlCommand.Parameters.AddWithValue("@student_no", student_no);

            DataAccessLayer dal = new DataAccessLayer();

            if(dal.connectionOpen())
            {
                result = dal.returnValue(sqlCommand);
                dal.connectionClose();
            }
            return result;

        }
    }


}