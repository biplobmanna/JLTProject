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
    public class JobBAL
    {
        private JobDAL _jobDal;

        public JobBAL()
        {
            _jobDal = new JobDAL();
        }

        public DataTable GetJobDetails(int companyId) => _jobDal.GetJobDetails(companyId);

        public bool AddJobs(string jobTitle, int companyId, int jobCategoryId)
        {
            Job job = new Job();
            job.JobId = _jobDal.GetNextJobId();
            job.JobTitle = jobTitle;
            job.CompanyId = companyId;
            job.JobCategoryId = jobCategoryId;

            return 1 == _jobDal.AddJobs(job);
        }

        public DataTable SearchJobs(int cityId, int jobCategoryId) => _jobDal.SearchJobs(cityId, jobCategoryId);
    }
}
