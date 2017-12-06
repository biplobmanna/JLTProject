using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using BO;
namespace WebUI
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CityBAL cityBal = new CityBAL();
                JobCategoryBAL jobCategoryBal = new JobCategoryBAL();
                var citiesTable = cityBal.GetCities();
                var jobCategoryTable = jobCategoryBal.GetJobCategory();
                foreach (DataRow row in citiesTable.Rows)
                {
                    // Creating a list-item with key-value pair of City-CityId
                    ListItem li = new ListItem(row[1].ToString(),row[0].ToString());
                    DropDownListCity.Items.Add(li);
                    DropDownListCompanyCity.Items.Add(li);
                }
                foreach (DataRow row in jobCategoryTable.Rows)
                {
                    ListItem li = new ListItem(row[1].ToString(), row[0].ToString());
                    DropDownJobCategory.Items.Add(li);
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            JobSeeker jobSeeker = new JobSeeker();
            jobSeeker.JobSeekerName = TextBoxName.Text;
            jobSeeker.JobSeekerDetails = TextBoxDetails.Text;
            // To-Do: Get the CityId from the CityTable
            // Get the JobCategoryId from the JobCategoryTable
            
            jobSeeker.CityId = Convert.ToInt32(DropDownListCity.SelectedValue);
            jobSeeker.JobCategoryId = Convert.ToInt32(DropDownJobCategory.SelectedValue);

            Credential credential = new Credential();
            credential.UserName = TextBoxUsername.Text;
            credential.Password = TextBoxPassword.Text;

            JobSeekerBAL jobSeekerBal = new JobSeekerBAL();
            jobSeekerBal.SaveJobSeeker(jobSeeker, credential);
        }

        protected void DropDownListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListCategory.SelectedValue.Equals("Company"))
            {
                DivJobSeekerRegister.Visible = false;
                DivCompanyRegister.Visible = true;
            }
            else
            {
                DivCompanyRegister.Visible = false;
                DivJobSeekerRegister.Visible = true;
            }
        }

        protected void ButtonSubmitCompany_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.CompanyName = TextBoxCompanyName.Text;
            company.Address = TextBoxAddressCompany.Text;
            company.ContactPersonName = TextBoxCompanyContactPersonName.Text;
            company.ContactPersonEmail = TextBoxCompanyContactPersonEmail.Text;
            company.ContactPersonPhone = TextBoxCompanyContactPersonPhone.Text;
            company.CityId = Convert.ToInt32(DropDownListCompanyCity.SelectedValue);

            Credential credential = new Credential();
            credential.UserName = TextBoxUsernameCompany.Text;
            credential.Password = TextBoxCompanyPassword.Text;

            CompanyBAL companyBal = new CompanyBAL();
            companyBal.SaveCompany(company, credential);
        }
    }
}