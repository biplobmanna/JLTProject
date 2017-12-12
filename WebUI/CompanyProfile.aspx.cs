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
                //Session["UserId"] = 2002;
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
                GridViewDisplayJobDetails.SelectedIndexChanged += GridViewDisplayJobDetails_SelectedIndexChanged;

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
            if (
                jobBal.AddJobs(
                    TextBoxJobName.Text,
                    Convert.ToInt32(Session["UserId"]),
                    Convert.ToInt32(DropDownListJobCategory.SelectedValue)
                )
            )
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Added Successfully!');",
                    true);
                PopulateGridViewDisplayJobDetails(Convert.ToInt32(Session["UserId"]));
                LabelHidden.InnerText = "divViewJobs";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Added Successfully!');", true);
                LabelHidden.InnerText = "divAddJobs";
            }
        }

        protected void GridViewDisplayJobDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Display The Jobs applied here
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "alert('Index Changed!');",
            //    true);
            var jobId = Convert.ToInt32(GridViewDisplayJobDetails.SelectedRow.Cells[1].Text.Trim());
            CompanyBAL companyBal = new CompanyBAL();
            var table = companyBal.GetJobApplicants(jobId);
            if (table.Rows.Count > 0)
            {
                GridViewJobApplicants.DataSource = table;
                GridViewJobApplicants.DataBind();
                LabelJobApplicantsHeader.InnerText = ""+jobId+":"+
                                                     GridViewDisplayJobDetails.SelectedRow.Cells[3].Text.Trim()+" - Job Applicants";
                LabelHidden.InnerText = "divJobApplicants";
            }
            else
            {
                LabelHidden.InnerText = "divViewJobs";
            }
            
            
        }
    }
}