using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGithub01.DataAccess
{
   public class SqlUnitOfWork
    {

        private string connectionString;

        public SqlUnitOfWork(string serverName, string dbName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.InitialCatalog = "LearnCell";
            builder.IntegratedSecurity = true;
            builder.ConnectTimeout = 30;


            
            connectionString = builder.ConnectionString;
        }

        public CustomerRepository Customers
        {
            get
            {
                return new CustomerRepository(connectionString);
            }
        }
        public EmployeeRepository Employees
        {
            get
            {
                return new EmployeeRepository(connectionString);
            }
        }
    }
}
