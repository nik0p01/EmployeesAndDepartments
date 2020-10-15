using EmployeesDepartments.DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartments.DAL.Repository
{
    public class RepositoryMSSQLStoredProcedures : IRepository
    {
        private readonly string _connectionString;
        public RepositoryMSSQLStoredProcedures(string connectionString)
        {
            _connectionString = connectionString;
        }
        //public RepositoryMSSQLStoredProcedures()
        //{
            
        //    _connectionString = Configuration.GetSection("ConnectionStrings");
        //}
        

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
                    ParameterName = "@idWorkingRates",
                    Value = employeeWorkingRate.workingRate.id
                };

                foreach (var sqlParameter in sqlParameters)
                {
                    command.Parameters.Add(sqlParameter);
                }

                command.ExecuteScalar();

            }
        }

        public void AddWorkingRate(WorkingRate workingRate)
        {
            string sqlExpression = "AddWorkingRate";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter
                {
                    ParameterName = "@namePosition",
                    Value = workingRate.workPositions.name
                };
                sqlParameters[1] = new SqlParameter
                {
                    ParameterName = "@Chief",
                    Value = workingRate.chief
                };
                sqlParameters[2] = new SqlParameter
                {
                    ParameterName = "@idDepartment",
                    Value = workingRate.department.id
                };


                foreach (var sqlParameter in sqlParameters)
                {
                    command.Parameters.Add(sqlParameter);
                }

                command.ExecuteScalar();
            }
        }

        public List<WorkingRate> GetAllWorkPositionWithDepartment()
        {
            string sqlExpression = "GetAllWorkPositionWithDepartment";
            List<WorkingRate> workPositions = new List<WorkingRate>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                  
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        workPositions.Add(new WorkingRate() { id = reader.GetInt32(2),
                            department = new Department() { name = reader.GetString(0) }, 
                            workPositions = new WorkPosition() { name = reader.GetString(1) } 
                        });
                       
                    }
                }
                reader.Close();
            }

            return workPositions;
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
