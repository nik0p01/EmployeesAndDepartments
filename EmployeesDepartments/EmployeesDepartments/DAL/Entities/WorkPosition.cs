using System.Collections.Generic;

namespace EmployeesDepartments.DAL.Entities
{
    public class WorkPosition
    {
        public int id;
        public string name;
        public List<WorkingRate> workingRates;
    }
}
