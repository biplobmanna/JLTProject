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
    }
}
