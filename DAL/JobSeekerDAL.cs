using System.Data;
using System.Data.SqlClient;
using BO;

namespace DAL
{
    public class JobSeekerDAL
    {
        private  SqlConnection _connection;
        private SqlCommand _command;

        public JobSeekerDAL()
        {
            _connection = new SqlConnection
            (
                @"Data Source=JLTMUMS-18\SQLEXPRESS2014;Initial Catalog=ProjectDB;Integrated Security=True"
            );

        }

        public int AddJobSeeker(JobSeeker jobSeeker)
        {
            var numberOfRowsAdded = 0;
            
            _command = new SqlCommand
            {
                CommandText = "AddJobSeeker",
                CommandType = CommandType.StoredProcedure
            };
            _command.Parameters.AddWithValue("@JobSeekerName", jobSeeker.JobSeekerName);
            _command.Parameters.AddWithValue("@CityId", jobSeeker.CityId);
            _command.Parameters.AddWithValue("@JobSeekerDetails", jobSeeker.JobSeekerDetails);
            _command.Parameters.AddWithValue("@JobCategoryId", jobSeeker.JobCategoryId);
            try
            {
                _connection.Open();
                _command.Connection = _connection;
                numberOfRowsAdded = _command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
            }
            finally
            {
                _connection.Close();
            }
            return numberOfRowsAdded;
        }
    }

}
