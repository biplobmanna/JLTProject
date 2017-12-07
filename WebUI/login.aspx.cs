using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace WebUI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            CredentialBAL credentialBal = new CredentialBAL();
            int credentialId = credentialBal.VerifyCredentials(TextBoxUsername.Text, TextBoxPassword.Text);
            if (credentialId != 0)
            {
                LabelLoginMessage.Text = "Login Successful: "+credentialId;
                SetSessionObject(credentialId);
                //To-Do: Redirect it to the respectieve profile page
            }
            else
            {
                LabelLoginMessage.Text = "Login Failed!!";
                TextBoxUsername.BorderColor = Color.Red;
                TextBoxPassword.BorderColor = Color.Red;
            }
        }

        private void SetSessionObject(int credentialId) =>
            Session["UserId"] = credentialId;
    }
}