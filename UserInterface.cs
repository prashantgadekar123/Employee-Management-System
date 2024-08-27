using System;
using System.Data;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Employee Management System");
                Console.WriteLine("1. View All Employees");
                Console.WriteLine("2. Add New Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var employees = employeeDAL.GetAllEmployees();
                        foreach (DataRow row in employees.Rows)
                        {
                            Console.WriteLine($"{row["EmployeeID"]}. {row["Name"]} - {row["Position"]} - {row["Department"]} - ${row["Salary"]}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Position: ");
                        string position = Console.ReadLine();
                        Console.Write("Enter Department: ");
                        string department = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());

                        employeeDAL.AddEmployee(name, position, department, salary);
                        Console.WriteLine("Employee added successfully.");
                        break;
                    case "3":
                        Console.Write("Enter Employee ID to Update: ");
                        int updateID = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Enter New Position: ");
                        string updatePosition = Console.ReadLine();
                        Console.Write("Enter New Department: ");
                        string updateDepartment = Console.ReadLine();
                        Console.Write("Enter New Salary: ");
                        decimal updateSalary = decimal.Parse(Console.ReadLine());

                        employeeDAL.UpdateEmployee(updateID, updateName, updatePosition, updateDepartment, updateSalary);
                        Console.WriteLine("Employee updated successfully.");
                        break;
                    case "4":
                        Console.Write("Enter Employee ID to Delete: ");
                        int deleteID = int.Parse(Console.ReadLine());
                        employeeDAL.DeleteEmployee(deleteID);
                        Console.WriteLine("Employee deleted successfully.");
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
