using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            if (new CredentialBAL().IsCredentialPresent(TextBoxUsername.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Username taken!');", true);
                TextBoxUsername.BorderColor = Color.Red;
                return;
            }

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

            //TO-DO: Check for the validity of username from the Credentials DB
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Registered Successfully! Please Login.');", true);
            Response.Redirect("login.aspx");
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
            if (new CredentialBAL().IsCredentialPresent(TextBoxUsernameCompany.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page,Page.GetType(),"text","alert('Username taken!');",true);
                TextBoxUsernameCompany.BorderColor = Color.Red;
                return;
            }

            Credential credential = new Credential
            {
                UserName = TextBoxUsernameCompany.Text,
                Password = TextBoxCompanyPassword.Text
            };
            Company company = new Company
            {
                CompanyName = TextBoxCompanyName.Text,
                Address = TextBoxAddressCompany.Text,
                ContactPersonName = TextBoxCompanyContactPersonName.Text,
                ContactPersonEmail = TextBoxCompanyContactPersonEmail.Text,
                ContactPersonPhone = TextBoxCompanyContactPersonPhone.Text,
                CityId = Convert.ToInt32(DropDownListCompanyCity.SelectedValue)
            };


            CompanyBAL companyBal = new CompanyBAL();
            companyBal.SaveCompany(company, credential);
            //TO-DO: Check for the validity of username from the Credentials DB
            //ScriptManager.RegisterStartupScript(this.Page,Page.GetType(),"text","alert('Registered Successfully! Please Login.');",true);
            Response.Redirect("login.aspx");
        }
    }
}