using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class JobsAppliedBAL
    {
        private JobsAppliedDAL _jobsAppliedDal;

        public JobsAppliedBAL()
        {
            _jobsAppliedDal = new JobsAppliedDAL();
        }

        public bool AddNewJobApplication(int jobId, int jobSeekerId) =>
            1 == _jobsAppliedDal.AddNewJobApplication(jobId, jobSeekerId);

        public bool IsAlreadyAppliedJob(int jobId, int jobSeekerId) =>
            0 == _jobsAppliedDal.JobAlreadyApplied(jobId, jobSeekerId);

        public DataTable FetchAllAppliedJobsDetails(int jobSeekerId) =>
            _jobsAppliedDal.FetchAllJobsAppliedDetails(jobSeekerId);
    }
}
