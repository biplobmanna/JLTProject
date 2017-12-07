using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using BO;

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
                CompanyBAL companyBal = new CompanyBAL();
                Company company = new Company();
                company = companyBal.GetCompanyDetails(Convert.ToInt32(Session["UserId"]));
                // Populate the Company Details Division
                LabelCompanyId.Text = company.CompanyId.ToString();
                LabelCompanyName.Text = company.CompanyName;
                LabelAddress.Text = company.Address;
                LabelCity.Text = new CityBAL().GetCity(company.CityId);
                LabelContactPersonName.Text = company.ContactPersonName;
                LabelContactPersonEmail.Text = company.ContactPersonEmail;
                LabelContactPersonPhone.Text = company.ContactPersonPhone;
            }
        }
    }
}