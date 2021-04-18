using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentInternship
{
    public partial class Company1 : System.Web.UI.Page
    {
        static Company company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCompanyName.ReadOnly = true;
            txtCompanyAddress.ReadOnly = true;
            txtCompanyNIP.ReadOnly = true;
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            int company_no;
            if (txtCompanyNIP.Text.Length > 0)
                company_no = Convert.ToInt32(txtCompanyNIP.Text);
            else
                company_no = 0;
            int result = company.getCompanyPersonalDetails(company_no);
            if (result == 1)
            {
                lblCompanyPK.Text = company.companyPK.ToString();
                txtCompanyName.Text = company.companyName;
                txtCompanyAddress.Text = company.companyAddress;
                txtCompanyNIP.Text = company.companyNo.ToString();
            }
            else
            {
                clearControls();
                lblInfo1.Text = "There is no company";
            }
            RadioButtonList1.SelectedValue = "None";
        }

        private void clearControls()
        {
            lblCompanyPK.Text = " - not set -";
            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";
            txtCompanyNIP.Text = "";

        }

        protected void btnInsert1_Click(object sender, EventArgs e)
        {
                string c_name = txtCompanyName.Text;
                string c_address = txtCompanyAddress.Text;
                int company_num = Convert.ToInt32(txtCompanyNIP.Text);
                

                company.setCompanyProperties(c_name, c_address, company_num);

                lblInfo1.Text = company.insertNewCompany();
                clearControls();
                RadioButtonList1.SelectedValue = "None";
            }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RadioButtonList1.SelectedValue)
            {
                case "Search":
                    {
                        clearControls();
                        txtCompanyNIP.ReadOnly = false;
                    }
                    break;
                case "Insert":
                    {
                        clearControls();
                        txtCompanyName.ReadOnly = false;
                        txtCompanyAddress.ReadOnly = false;
                        txtCompanyNIP.ReadOnly = false;
                       
                    }
                    break;
            }
    }
    }

   

}
