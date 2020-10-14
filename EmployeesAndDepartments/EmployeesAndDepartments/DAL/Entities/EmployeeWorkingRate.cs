using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartments.DAL.Entities
{
    public class EmployeeWorkingRate
    {
        public Employee employee;
        public bool halfRate;
        public WorkingRate workingRate;

    }
}
