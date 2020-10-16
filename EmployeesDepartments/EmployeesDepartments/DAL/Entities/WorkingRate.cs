using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartments.DAL.Entities
{
    public class WorkingRate
    {
        public int id;
        public Department department;
        public WorkPosition workPosition;
        public bool chief;
        public List<EmployeeWorkingRate> employeeWorkingRates;
    }
}
