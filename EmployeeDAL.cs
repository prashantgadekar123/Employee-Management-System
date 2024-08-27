using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
    public class EmployeeDAL
    {
        private string connectionString = "your_connection_string_here";

        public DataTable GetAllEmployees()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable employees = new DataTable();
                adapter.Fill(employees);
                return employees;
            }
        }

        public void AddEmployee(string name, string position, string department, decimal salary)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employees (Name, Position, Department, Salary) VALUES (@Name, @Position, @Department, @Salary)", conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Salary", salary);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(int id, string name, string position, string department, decimal salary)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employees SET Name=@Name, Position=@Position, Department=@Department, Salary=@Salary WHERE EmployeeID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Position", position);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@Salary", salary);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
