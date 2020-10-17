using System.Collections.Generic;

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
