using EmployeesDepartments.DAL.Entities;
using System.Collections.Generic;

namespace EmployeesDepartments.DAL.Repository
{
    public interface IRepository
    {
        public void AddEmployee(EmployeeWorkingRate employeeWorkingRate);
        public void AddWorkingRate(WorkingRate workingRate);
        public List<Department> GetDepartmentsWithChief();
        public List<Department> GetAllDepartments();
        public List<Employee> GetAllEmployees();
        public List<Employee> GetEmpoyeesByDepartmentId(Department department);
        public List<WorkingRate> GetAllWorkPositionWithDepartment();
        public List<WorkingRate> GetFreeRates();
        public void EditEmpoyeeById(Employee employee);
        public void EditWorkingRates(WorkingRate workingRate);
    }
}
