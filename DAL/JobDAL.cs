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
    public class JobDAL
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public JobDAL()
        {
            _connection = new SqlConnection
            (
                @"Data Source=JLTMUMS-18\SQLEXPRESS2014;Initial Catalog=ProjectDB;Integrated Security=True"
            );
        }

        public DataTable GetJobDetails(int companyId)
        {
            var table = new DataTable();
            var commandText = "GetJobDetails " + companyId;
            var adapter = new SqlDataAdapter(commandText,_connection);
            try
            {
                adapter.Fill(table);
            }
            catch
            {
            }
            return table;
        }

        public int AddJobs(Job job)
        {
            _command = new SqlCommand
            {
                CommandText = "AddJobs",
                CommandType = CommandType.StoredProcedure
            };
            _command.Parameters.AddWithValue("@JobId", job.JobId);
            _command.Parameters.AddWithValue("@JobTitle", job.JobTitle);
            _command.Parameters.AddWithValue("@CompanyId", job.CompanyId);
            _command.Parameters.AddWithValue("@JobCategoryId", job.JobCategoryId);

            var rowsAdded=0;
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
        public int GetNextJobId()
        {
            var jobId = 0;
            _command = new SqlCommand
            {
                CommandText = "GetNextJobId",
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _connection.Open();
                _command.Connection = _connection;
                jobId = Convert.ToInt32(_command.ExecuteScalar());
            }
            catch
            {

            }
            finally
            {
                _connection.Close();
            }
            return jobId;
        }

        public DataTable SearchJobs(int cityId, int jobCategoryId)
        {
            var table = new DataTable();
            var commandText = "GetJobApplyDetails " + cityId + ", " + jobCategoryId;
            var adapter = new SqlDataAdapter(commandText,_connection);
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
