using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class JobsAppliedDAL
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public JobsAppliedDAL()
        {
            _connection = new SqlConnection
            (
                @"Data Source=JLTMUMS-18\SQLEXPRESS2014;Initial Catalog=ProjectDB;Integrated Security=True"
            );
        }

        public int AddNewJobApplication(int jobId, int jobSeekerId)
        {
            _command = new SqlCommand
            {
                CommandText = "ApplyJobs",
                CommandType = CommandType.StoredProcedure
            };
            _command.Parameters.AddWithValue("@JobId", jobId);
            _command.Parameters.AddWithValue("@JobSeekerId", jobSeekerId);

            var rowsAdded = 0;
            try
            {
                _connection.Open();
                _command.Connection = _connection;
                rowsAdded = _command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                _connection.Close();
            }
            return rowsAdded;
        }

        public int JobAlreadyApplied(int jobId, int jobSeekerId)
        {
            _command = new SqlCommand
            {
                CommandText = "JobsAlreadyApplied",
                CommandType = CommandType.StoredProcedure
            };
            _command.Parameters.AddWithValue("@JobId", jobId);
            _command.Parameters.AddWithValue("@JobSeekerId", jobSeekerId);

            var jobCount = 0;
            try
            {
                _connection.Open();
                _command.Connection = _connection;
                jobCount = Convert.ToInt32(_command.ExecuteScalar());
            }
            catch
            {
            }
            finally
            {
                _connection.Close();
            }
            return jobCount;
        }

        public DataTable FetchAllJobsAppliedDetails(int jobSeekerid)
        {
            var commandText = "GetAllAppliedJobDetails " + jobSeekerid;
            var adapter = new SqlDataAdapter(commandText,_connection);
            var table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch
            {
            }
            return table;
        }
    }
}
