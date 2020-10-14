using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartments.DAL.Entities
{
    public class Employee
    {
        public int id;
        public string name;
        public string email;
        public List<EmployeeWorkingRate> employeeWorkingRates;  
    }
}
