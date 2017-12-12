using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;

namespace WebUI
{
    public partial class JobSeekerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Creating Session Object
                //Session["UserId"] = 1001;
                //Delete the above portion

                //Populating JS Details
                JobSeekerBAL jobSeekerBal = new JobSeekerBAL();
                var table = jobSeekerBal.GetJobSeekerDetails(Convert.ToInt32(Session["UserId"]));
                LabelJobSeekerId.Text = table.Rows[0][0].ToString();
                LabelJobSeekerName.Text = table.Rows[0][1].ToString();
                LabelCity.Text = table.Rows[0][2].ToString();
                LabelDetails.Text = table.Rows[0][3].ToString();
                LabelJobCategory.Text = table.Rows[0][4].ToString();
                Session["JobCategoryId"] = table.Rows[0][5].ToString();
                //populating City DropDown
                var cityBal = new CityBAL();
                var citiesTable = cityBal.GetCities();
                foreach (DataRow row in citiesTable.Rows)
                {
                    var li = new ListItem(row[1].ToString(), row[0].ToString());
                    DropDownListCity.Items.Add(li);
                }
                //Populate Applied Jobs GridView
                PopulateGridViewAppliedJobs();
            }
        }

        //protected override void OnLoadComplete(EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(this.Page,Page.GetType(),"text","showDivViewJobs()",true);
        //}

        private void PopulateGridViewAppliedJobs()
        {
            var jobsAppliedBal = new JobsAppliedBAL();
            var table = jobsAppliedBal.FetchAllAppliedJobsDetails(Convert.ToInt32(Session["UserId"]));
            GridViewAppliedJobs.DataSource = table;
            GridViewAppliedJobs.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            JobBAL jobBal  = new JobBAL();
            var table = jobBal.SearchJobs(
                Convert.ToInt32(DropDownListCity.SelectedValue),
                Convert.ToInt32(Session["JobCategoryId"])
            );
            GridViewJobs.DataSource = table;
            GridViewJobs.DataBind();
            LabelHidden.InnerText = "divViewJobs";
        }

        protected void ButtonApplyJob_Click(object sender, EventArgs e)
        {
            JobsAppliedBAL jobsAppliedBal = new JobsAppliedBAL();
            LabelHidden.InnerText = "divViewJobs";
            foreach (GridViewRow row in GridViewJobs.Rows)
            {
                if (!(row.Cells[0].FindControl("CheckBoxJobSelect") as CheckBox).Checked) continue;
                var jobId = Convert.ToInt32(row.Cells[1].Text);
                var jobSeekerId = Convert.ToInt32(Session["UserId"]);
                if (jobsAppliedBal.IsAlreadyAppliedJob(jobId, jobSeekerId))
                {
                    jobsAppliedBal.AddNewJobApplication(jobId, jobSeekerId);
                    row.ForeColor = Color.White;
                    row.BackColor = Color.DarkGreen;
                }
                else
                {
                    row.ForeColor = Color.White;
                    row.BackColor = Color.DarkRed;
                }
            }
            PopulateGridViewAppliedJobs();
        }
    }
}