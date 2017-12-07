using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BO;

namespace DAL
{
    public class CityDAL
    {
        private  SqlConnection _connection;
        private SqlCommand _command;

        public CityDAL()
        {
            _connection = new SqlConnection
            (
                @"Data Source=JLTMUMS-18\SQLEXPRESS2014;Initial Catalog=ProjectDB;Integrated Security=True"
            );
        }
        public DataTable GetCities()
        {
            DataTable table = new DataTable();
            var adapter = new SqlDataAdapter("GetCitiesWithId", _connection);
            try
            {
                adapter.Fill(table);
            }
            catch (SqlException se)
            {
            }
            return table;
        }

        public string GetCity(int id)
        {
            var table = new DataTable();
            string commandText = "GetCity " + id;
            var adapter = new SqlDataAdapter(commandText,_connection);
            try
            {
                adapter.Fill(table);
            }
            catch(Exception e)
            {
            }
            return table.Rows.Count == 1 ? table.Rows[0][0].ToString() : null;
        }
    }
}
