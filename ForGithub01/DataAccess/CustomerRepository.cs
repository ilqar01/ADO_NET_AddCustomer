using ForGithub01.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGithub01.DataAccess
{



    public class CustomerRepository
    {

        private readonly string connectionString;

        public CustomerRepository(string connectionString) // Constructor eklendi
        {
            this.connectionString = connectionString;
        }

        public List<Customer> GetCustomers()
      {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {




            connection.Open();

            List<Customer> customers = new List<Customer>();

            string query = "select * from Customers";

            using (SqlCommand command = new SqlCommand(query, connection))
            {


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer();
                    //
                    customer.Id = (int)reader["id"];
                    customer.Name = (string)reader["name"];
                    customer.Surname = (string)reader["surname"];
                    //
                    customers.Add(customer);
                }



                return customers;
            }

        }
    }

    public Customer GetCustomer(int id)
    {
        return null;
    }



    public int AddCustomers(Customer customer)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            connection.Open();
            string query = $"insert into Customers output inserted.id values (@name ,@surname)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", customer.Name);
            command.Parameters.AddWithValue("@surname", customer.Surname);
            int id = (int)command.ExecuteScalar();

            return id;
        }



    }


    public void UpdateCustomer(Customer customer)
    {

    }

    public void DeleteCustomer(int id)
    {

    }

   }
}

