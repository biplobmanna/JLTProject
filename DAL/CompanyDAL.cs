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
    public class CompanyDAL
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public CompanyDAL()
        {
            _connection = new SqlConnection
            (
                @"Data Source=JLTMUMS-18\SQLEXPRESS2014;Initial Catalog=ProjectDB;Integrated Security=True"
            );
        }
        public int AddCompany(Company company)
        {
            var numberOfRowsAdded = 0;

            _command = new SqlCommand
            {
                CommandText = "AddCompany",
                CommandType = CommandType.StoredProcedure
            };
            _command.Parameters.AddWithValue("@CompanyName", company.CompanyName);
            _command.Parameters.AddWithValue("@Address", company.Address);
            _command.Parameters.AddWithValue("@CityId", company.CityId);
            _command.Parameters.AddWithValue("@ContactPersonName", company.ContactPersonName);
            _command.Parameters.AddWithValue("@ContactPersonEmail", company.ContactPersonEmail);
            _command.Parameters.AddWithValue("@ContactPersonPhone", company.ContactPersonPhone);
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

        public Company GetCompanyDetails(int companyId)
        {
            var companyDetails = new Company();
            var commandText = "GetCompanyDetails " + companyId;
            var adapter = new SqlDataAdapter(commandText, _connection);
            var table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (Exception e)
            {
            }
            if (table.Rows.Count != 1) return null;
            var row = table.Rows[0].ItemArray;
            companyDetails.CompanyId = Convert.ToInt32(row[0]);
            companyDetails.CompanyName = row[1].ToString();
            companyDetails.Address = row[2].ToString();
            companyDetails.CityId = Convert.ToInt32(row[3]);
            companyDetails.ContactPersonName = row[4].ToString();
            companyDetails.ContactPersonEmail = row[5].ToString();
            companyDetails.ContactPersonPhone = row[6].ToString();

            return companyDetails;
        }

        public DataTable GetJobApplicants(int jobId)
        {
            var table = new DataTable();
            var commandText = "GetJobApplicants " + jobId;
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
