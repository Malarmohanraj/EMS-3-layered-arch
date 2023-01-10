using Capgemini.EMS.BussinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;

namespace Capgemni.EMS.PL
{
    internal class Program
    {
        //private static object ex;

        private static void Main(string[] args)
        {
            while (true)
            {


                Console.WriteLine("1. Add employee, 2. Employeee List, 3. Update employee," +
                    " 4. DeleteEmployee, 5. Exit");
                Console.WriteLine("Enter your choice");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        EmployeeList();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;



                   // default:
                      //  Console.WriteLine("Invalid");
                       // break;
                }
            }

        }

        private static void DeleteEmployee()
        {
            Employee newEmp = new Employee();
            string input;
            int empId;
           // DateTime dateOfJoinning;
            do
            {
                Console.WriteLine("Enter employee Id ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out empId));
            newEmp.Id = empId;
            //emp id
            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee not found");
                return;
            }

            var isDeleted = EmployeeBL.Delete(newEmp);
            if (isDeleted)
            {
                Console.WriteLine("Deleted successfully");
            }
            else
            {
                Console.WriteLine("Employee deleting failed");
            }


        }

        private static void UpdateEmployee()
        {
            //emp id
            string input;
            int empId;
            do
            {
                Console.WriteLine("Enter employee Id ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out empId));
            //emp id
            var existingEmployee = EmployeeBL.GetById(empId);
            if(existingEmployee== null)
            {
                Console.WriteLine("Employee not found");
                return;
            }

            //name/doj
            Employee newEmp = new Employee();
            newEmp.Id = empId;
            do
            {
                Console.WriteLine("Enter Name");
                input = Console.ReadLine();

            } while (string.IsNullOrEmpty(input));
            newEmp.Name = input;

            DateTime dateOfJoinning;
            do
            {
                Console.WriteLine("Enter date of joinning ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoinning));
            newEmp.DateOfJoinning = dateOfJoinning;

            //update

            var isUpdated = EmployeeBL.Update(newEmp);
            if(isUpdated)
            {
                Console.WriteLine("Employee Updated successfully");
            }
            else
            {
                Console.WriteLine("Employee update failed");
            }



        }

        private static void EmployeeList()
        {
            var list = EmployeeBL.GetList();
            Console.WriteLine("Employee list");
            foreach(var emp in list)
            {
                Console.WriteLine(emp);
            }
        }

        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();

            string input;
            int empId;
            do
            {
                Console.WriteLine("Enter employee Id ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out empId));
            newEmployee.Id = empId;
            do
            {
                Console.WriteLine("Enter Name");
                input = Console.ReadLine();

            } while (string.IsNullOrEmpty(input));
            newEmployee.Name = input;

            DateTime dateOfJoinning;
            do
            {
                Console.WriteLine("Enter date of joinning ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoinning));
            newEmployee.DateOfJoinning = dateOfJoinning;

            try
            {
                bool isAdded = EmployeeBL.Add(newEmployee);
                if (isAdded)
                {
                    Console.WriteLine("Employee added sucessfuly");
                }
                else
                {
                    Console.WriteLine("Employee add failed");
                }
            }
            catch (EmsException ex)
            {


                Console.WriteLine(ex.Message);
            }



        }
    }

    
}
