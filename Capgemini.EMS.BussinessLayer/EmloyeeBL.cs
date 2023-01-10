using Capgemini.EMS.DataAccessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;
using System.Collections.Generic;

namespace Capgemini.EMS.BussinessLayer
{
    public class EmployeeBL
    {
        public static bool Add(Employee emp)
        {

            if(emp.Id <= 0)
            {
                throw new EmsException("Employee Id should be greater than zero");
            }

            bool isAdded = EmployeeDAL.Add(emp);
            return isAdded;
        }
        public static List<Employee> GetList()
        {
            var list = EmployeeDAL.GetList();
            return list;
        }

        //get by id
        public static Employee GetById(int id)
        {
            var emp = EmployeeDAL.GetById(id);
            return emp;
        }

        //updating
        public static bool Update(Employee emp)
        {
            bool isUpdated = EmployeeDAL.Update(emp);
            return isUpdated;
        }

        //deleting
        public static bool Delete(Employee emp)
        {
            bool isDeleted = EmployeeDAL.Delete(emp);
            return isDeleted;
        }
    }
}
