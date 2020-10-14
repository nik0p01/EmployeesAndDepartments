using EmployeesAndDepartments.DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAndDepartments.DAL.Repository
{
    public class RepositoryMSSQLStoredProcedures : IRepository
    {
        private readonly string _connectionString;
        public RepositoryMSSQLStoredProcedures(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void AddEmployee(EmployeeWorkingRate employeeWorkingRate)
        {

            string sqlExpression = "AddEmployee";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[4];
                sqlParameters[0] = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = employeeWorkingRate.employee.name
                };
                sqlParameters[1] = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = employeeWorkingRate.employee.email
                };
                sqlParameters[2] = new SqlParameter
                {
                    ParameterName = "@HalfRate",
                    Value = employeeWorkingRate.halfRate
                };
                sqlParameters[3] = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = employeeWorkingRate.workingRate.id
                };

                foreach (var sqlParameter in sqlParameters)
                {
                    command.Parameters.Add(sqlParameter);
                }

               command.ExecuteNonQuery();
            }
        }

        public void AddWorkingRate(WorkingRate workingRate)
        {
            throw new NotImplementedException();
        }

        public List<WorkPosition> GetAllWorkPositionWithDepartment()
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartmentsWithChief()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmpoyeesByDepartmentId(Department department)
        {
            throw new NotImplementedException();
        }

        public List<WorkingRate> GetFreeRates()
        {
            throw new NotImplementedException();
        }
    }
}
