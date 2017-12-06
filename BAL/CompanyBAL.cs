using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class CompanyBAL
    {
        private CompanyDAL companyDal;
        private CredentialDAL _credentialDal;

        public CompanyBAL()
        {
            companyDal = new CompanyDAL();
            _credentialDal = new CredentialDAL();
        }

        public int SaveCompany(Company company, Credential credential)
        {
            credential.CredentialId = _credentialDal.GetNextCompanyId();
            var numberOfJobSeekerAdded = companyDal.AddCompany(company);
            var numberOfCredentialAdded = _credentialDal.AddCredentials(credential);

            return numberOfCredentialAdded == 1
                   && numberOfJobSeekerAdded == 1
                ? 1 : 0;
        }
    }
}
