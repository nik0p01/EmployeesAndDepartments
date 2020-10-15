using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartments.DAL.Entities
{
    public class WorkPosition
    {
        public int id;
        public string name;
        public List<WorkingRate> WorkingRates;
    }
}
