﻿using EmployeesAndDepartments.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartments.DAL.Repository
{
    interface IRepository
    {
        public void AddEmployee(EmployeeWorkingRate employeeWorkingRate);
        public void AddWorkingRate(WorkingRate workingRate);
        public List<Department> GetDepartmentsWithChief();
        public List<Employee> GetEmpoyeesByDepartmentId(Department department);
        public List<WorkingRate> GetAllWorkPositionWithDepartment();
        public List<WorkingRate> GetFreeRates();
    }
}
