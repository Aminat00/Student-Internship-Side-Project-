using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentInternship
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static Student2 student2 = new Student2();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert1_Click(object sender, EventArgs e)
        {
            int student_no = Convert.ToInt32(TextBoxStudentID.Text);
            labStudentPK.Text = student2.getStudentPK(student_no).ToString();
        }
    }
}