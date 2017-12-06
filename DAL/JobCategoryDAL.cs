using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JobCategoryDAL
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public JobCategoryDAL()
        {
            _connection = new SqlConnection
            (
                @"Data Source=JLTMUMS-18\SQLEXPRESS2014;Initial Catalog=ProjectDB;Integrated Security=True"
            );
        }
        public DataTable GetJobCategory()
        {
            DataTable table = new DataTable();
            var adapter = new SqlDataAdapter("GetAllJobCategory", _connection);
            try
            {
                adapter.Fill(table);
            }
            catch (SqlException se)
            {
            }
            return table;
        }
    }
}
