using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartments.DAL.Entities
{ 
    public class Department
    {
        public int id;
        public string name;
        public List<Department> departmentsBottom;
        public Department departmentTop;
        public List<WorkingRate> WorkingRates;
    }
}
