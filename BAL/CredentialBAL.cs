using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class CredentialBAL
    {
        private CredentialDAL _credentialDal;

        public CredentialBAL()
        {
            _credentialDal = new CredentialDAL();
        }

        public int VerifyCredentials(string username, string password) =>
            _credentialDal.VerifyLoginCredentials(username, password);
    }
}
