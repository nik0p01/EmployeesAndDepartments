using System.Collections.Generic;

namespace EmployeesDepartments.DAL.Entities
{
    public class Employee
    {
        public int id;
        public string name;
        public string email;
        public List<EmployeeWorkingRate> employeeWorkingRates;
    }
}
