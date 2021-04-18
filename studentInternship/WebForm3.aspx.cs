using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentInternship
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        static Student student = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtStudentID.ReadOnly = true;
            txtFaculty.ReadOnly = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int student_no;
            if (txtStudentID.Text.Length > 0)
                student_no = Convert.ToInt32(txtStudentID.Text);
            else
                student_no = 0;
            int result = student.getStudentPersonalDetails(student_no);
            if (result == 1)
            {
                lblStudentPK.Text = student.studentPK.ToString();
                txtFirstName.Text = student.firstName;
                txtLastName.Text = student.lastName;
                txtStudentID.Text = student.studentNo.ToString();
                txtFaculty.Text = student.faculty;
            }
            else
            {
                clearControls();
                lblInfo.Text = "There is no student";
             }
            RadioButtonList2.SelectedValue = "None";
        }
       

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string f_name = txtFirstName.Text;
            string l_name = txtLastName.Text;
            int student_num = Convert.ToInt32(txtStudentID.Text);
            string facultya= txtFaculty.Text;

            student.setStudentProperties(f_name, l_name, student_num, facultya);

            lblInfo.Text = student.insertNewStudent();
            clearControls();
            RadioButtonList2.SelectedValue = "None";
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string f_name = txtFirstName.Text;
            string l_name = txtLastName.Text;

            if ((student.studentPK > 0) && ((f_name != student.firstName) || (l_name != student.lastName)))
            {
                lblInfo.Text = student.updateStudentDetails(f_name, l_name);
                clearControls();
            }
            RadioButtonList2.SelectedValue = "None";
        }

        
            

      

        private void clearControls()
        {
            lblStudentPK.Text = " - not set -";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtStudentID.Text = "";
            txtFaculty.Text = "";
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RadioButtonList2.SelectedValue)
            {
                case "Search":
                    {
                        clearControls();
                        txtStudentID.ReadOnly = false;
                    }
                    break;
                case "Insert":
                    {
                        clearControls();
                        txtFirstName.ReadOnly = false;
                        txtLastName.ReadOnly = false;
                        txtStudentID.ReadOnly = false;
                        txtFaculty.ReadOnly = false;
                    }
                    break;
                case "Update":
                    {
                        txtFirstName.ReadOnly = false;
                        txtLastName.ReadOnly = false;

                    }
                    break;
            }
        
    }
    }
   
}