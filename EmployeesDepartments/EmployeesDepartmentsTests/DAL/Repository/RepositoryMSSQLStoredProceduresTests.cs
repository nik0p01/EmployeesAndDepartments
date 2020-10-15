using Xunit;
using EmployeesDepartments.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesDepartments.DAL.Repository.Tests
{
    public class RepositoryMSSQLStoredProceduresTests
    {
        RepositoryMSSQLStoredProcedures repository = new RepositoryMSSQLStoredProcedures("Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=c:\\t2\\EmployeesAndDepartments.mdf;" +
                "Integrated Security=True;Connect Timeout=30");
        [Fact()]
        public void AddEmployeeTest()
        {


            repository.AddEmployee(new Entities.EmployeeWorkingRate()
            {
                employee = new Entities.Employee { email = "t@t1", name = "n1" },
                halfRate = true,
                workingRate = new Entities.WorkingRate { id = 1 }
            });

            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetAllWorkPositionWithDepartmentTest()
        {
            var result = repository.GetAllWorkPositionWithDepartment();
            Assert.True(result.Count > 0);
        }
    }
}