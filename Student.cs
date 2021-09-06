using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;


namespace studentInternship
{
    public class Student
    {
        public int studentPK { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public int studentNo { get; private set; }
        public string faculty { get; private set; }

        public int getStudentPK(int studentNo)
        {
            string query = "select Id_student from Students where studentNo= @studentNo";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@studentNo", studentNo);
            DataAccessLayer dal = new DataAccessLayer();
            if (dal.connectionOpen())
            {
                SqlDataReader reader = dal.returnReader(sqlCommand);
                if (reader.HasRows)
                {
                    reader.Read();
                    this.studentPK = Convert.ToInt32(reader[0].ToString());
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

        public int getStudentPersonalDetails(int studentNo)
        {
            string query = "select Id_student, firstName, lastName, studentNo, Faculty from Students where studentNo = @studentNo";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@studentNo", studentNo);
            DataAccessLayer dal = new DataAccessLayer();
            if (dal.connectionOpen())
            {
                SqlDataReader reader = dal.returnReader(sqlCommand);
                if (reader.HasRows)
                {
                    reader.Read();
                    this.studentPK = Convert.ToInt32(reader[0].ToString());
                    this.firstName = reader[1].ToString();
                    this.lastName = reader[2].ToString();
                    this.studentNo = Convert.ToInt32(reader[3].ToString());
                    this.faculty = reader[4].ToString();
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



        public string insertNewStudent()
        {
            string query = "insert into Students values(@fName, @lName, @studentNo, @faculty);";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@fName", this.firstName);
            sqlCommand.Parameters.AddWithValue("@lName", this.lastName);
            sqlCommand.Parameters.AddWithValue("@studentNo", this.studentNo);
            sqlCommand.Parameters.AddWithValue("@faculty", this.faculty);
            DataAccessLayer dal = new DataAccessLayer();

            try
            {
                dal.connectionOpen();
                if (getStudentPK(this.studentNo) == -1)
                {
                    dal.queryExecution(sqlCommand);
                    dal.connectionClose();
                    return "Congrats! New student is successfully inserted";
                }
                else
                {
                    dal.connectionClose();
                    return "The student with this ID" + this.studentNo.ToString() +
                        "  is already exist in our Database";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void setStudentProperties(string fName, string lName, int studentNo, string faculty)

        {
            this.studentPK = 0;
            this.firstName = fName;
            this.lastName = lName;
            this.studentNo = studentNo;
            this.faculty = faculty;
        }
        public void resetStudentProperties()
        {
            this.studentPK = 0;
            this.firstName = "";
            this.lastName = "";
            this.studentNo = 0;
            this.faculty = "";

        }

        public string updateStudentDetails(string name, string surname)
        {
            string query = "update Students set firstName = @name, lastName = @surname  where (studentNo = @studentNo) and (Id_student = @studentPK) ";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@surname", surname);
            sqlCommand.Parameters.AddWithValue("@faculty", this.faculty);
            sqlCommand.Parameters.AddWithValue("@studentNo", studentNo);
            sqlCommand.Parameters.AddWithValue("@studentPK", this.studentPK);
            DataAccessLayer dal = new DataAccessLayer();

            try
            {
                dal.connectionOpen();
                dal.queryExecution(sqlCommand);
                dal.connectionClose();
                return "Student data is updated";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }





        }


    }
}
