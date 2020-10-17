using Xunit;

namespace EmployeesDepartments.DAL.Repository.Tests
{
    public class RepositoryMSSQLStoredProceduresTests
    {
        RepositoryMSSQLStoredProcedures repository = new RepositoryMSSQLStoredProcedures("Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=c:\\t2\\EmployeesAndDepartments.mdf;" +
                "Integrated Security=True;Connect Timeout=30");


        [Fact()]
        public void GetAllWorkPositionWithDepartmentTest()
        {
            var result = repository.GetAllWorkPositionWithDepartment();
            Assert.True(result.Count > 0);
        }
    }
}