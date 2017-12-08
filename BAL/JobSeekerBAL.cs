using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class JobSeekerBAL
    {
        private JobSeekerDAL _jobSeekerDal;
        private CredentialDAL _credentialDal;
        public JobSeekerBAL()
        {
            _jobSeekerDal = new JobSeekerDAL();
            _credentialDal = new CredentialDAL();
        }

        public int SaveJobSeeker(JobSeeker jobSeeker, Credential credential)
        {
            credential.CredentialId = _credentialDal.GetNextJobSeekerId();
            var numberOfJobSeekerAdded = _jobSeekerDal.AddJobSeeker(jobSeeker);
            var numberOfCredentialAdded = _credentialDal.AddCredentials(credential);

            return numberOfCredentialAdded == 1
                   && numberOfJobSeekerAdded == 1
                ? 1 : 0;
        }

        public DataTable GetJobSeekerDetails(int jobSeekerId) => _jobSeekerDal.GetJobSeekerDetails(jobSeekerId);
    }
}
