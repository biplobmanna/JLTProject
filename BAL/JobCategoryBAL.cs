using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class JobCategoryBAL
    {
        private readonly JobCategoryDAL _jobCategoryDal;

        public JobCategoryBAL()
        {
            _jobCategoryDal = new JobCategoryDAL();
        }

        public DataTable GetJobCategory() => _jobCategoryDal.GetJobCategory();
    }
}
