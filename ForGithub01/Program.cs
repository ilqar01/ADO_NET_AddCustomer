using ForGithub01.DataAccess;
using ForGithub01.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGithub01
{
   

    internal class Program
    {


        static void Main(string[] args)
        {


            string serverName = "localhost";
            string dbName = "LearnCell";

            SqlUnitOfWork db = new SqlUnitOfWork(serverName, dbName);

            Console.WriteLine("Welcome");
            Console.WriteLine("Press 1 for Customers");
            Console.WriteLine("Press 2 for Employees");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:


                    List<Customer> customers = db.Customers.GetCustomers();


                    foreach (Customer customer in customers)
                    {
                        Console.WriteLine($"{customer.Id} {customer.Name} {customer.Surname}");
                    }

                    Console.WriteLine("Press 1 to add new customer");
                    Console.WriteLine("Press 2 to update existing customer");
                    Console.WriteLine("Press 3 to delete existing customer");
                    Console.WriteLine("Press 4 to return main menu");

                    break;

                case 2:


                    List<Employee> employees = db.Employees.GetEmployees();

                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine($"{employee.Id} {employee.Name} {employee.Surname}");
                    }

                    break;
            }







        }
    }
}