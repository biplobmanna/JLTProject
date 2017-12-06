using BO;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CredentialDAL
    {
        private  SqlConnection _connection;
        private SqlCommand _command;

        public CredentialDAL()
        {
            _connection = new SqlConnection
            (
                @"Data Source=JLTMUMS-18\SQLEXPRESS2014;Initial Catalog=ProjectDB;Integrated Security=True"
            );
        }
        public int AddCredentials(Credential Credential)
        {
            
            var numberOfRowsAdded = 0;
            _command = new SqlCommand
            {
                CommandText = "AddCredentials",
                CommandType = CommandType.StoredProcedure
            };
            _command.Parameters.AddWithValue("@UserName", Credential.UserName);
            _command.Parameters.AddWithValue("@Password", Credential.Password);
            _command.Parameters.AddWithValue("@CredentialId", Credential.CredentialId);
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

        public int GetNextJobSeekerId()
        {
            var NextJobSeekerId = 0;
            _command = new SqlCommand
            {
                CommandText = "GetNextJobSeeker",
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _connection.Open();
                _command.Connection = _connection;
                NextJobSeekerId = Convert.ToInt32(_command.ExecuteScalar());
            }
            catch (SqlException se)
            {
            }
            finally
            {
                _connection.Close();
            }
            return NextJobSeekerId;
        }

        public int GetNextCompanyId()
        {
            var NextCompanyId = 0;
            _command = new SqlCommand
            {
                CommandText = "GetNextCompanyId",
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                _connection.Open();
                _command.Connection = _connection;
                NextCompanyId = Convert.ToInt32(_command.ExecuteScalar());
            }
            catch (SqlException se)
            {
            }
            finally
            {
                _connection.Close();
            }
            return NextCompanyId;
        }

    }
}
