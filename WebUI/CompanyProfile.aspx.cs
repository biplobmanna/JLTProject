using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using BO;
using System.Windows.Forms;

namespace WebUI
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //TO-DO: Setting the session object which will be later removed
                Session["UserId"] = 2002;
                // Remove the above portion
                var companyBal = new CompanyBAL();
                var company = companyBal.GetCompanyDetails(Convert.ToInt32(Session["UserId"]));
                // Populate the Company Details Division
                LabelCompanyId.Text = company.CompanyId.ToString();
                LabelCompanyName.Text = company.CompanyName;
                LabelAddress.Text = company.Address;
                LabelCity.Text = new CityBAL().GetCity(company.CityId);
                LabelContactPersonName.Text = company.ContactPersonName;
                LabelContactPersonEmail.Text = company.ContactPersonEmail;
                LabelContactPersonPhone.Text = company.ContactPersonPhone;

                //Populating Job Details View Page
                PopulateGridViewDisplayJobDetails(Convert.ToInt32(Session["UserId"]));

                //Populating Jobs Added Page
                PopulateDropDownListJobCategory();
            }
        }

        private void PopulateGridViewDisplayJobDetails(int companyId)
        {
            var jobBal = new JobBAL();
            var table = jobBal.GetJobDetails(companyId);
            GridViewDisplayJobDetails.DataSource = table;
            GridViewDisplayJobDetails.DataBind();
        }

        private void PopulateDropDownListJobCategory()
        {
            var jobCategory = new JobCategoryBAL();
            var table = jobCategory.GetJobCategory();
            foreach (DataRow row in table.Rows)
            {
                var li = new ListItem(row[1].ToString(),row[0].ToString());
                DropDownListJobCategory.Items.Add(li);
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var jobBal = new JobBAL();
            if(
                jobBal.AddJobs(
                TextBoxJobName.Text,
                Convert.ToInt32(Session["UserId"]),
                Convert.ToInt32(DropDownListJobCategory.SelectedValue)
                )
            )
                MessageBox.Show("Added successfully!");
            PopulateGridViewDisplayJobDetails(Convert.ToInt32(Session["UserId"]));
            
        }
    }
}