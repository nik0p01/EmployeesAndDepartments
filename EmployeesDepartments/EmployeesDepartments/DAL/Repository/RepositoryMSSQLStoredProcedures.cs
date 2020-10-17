using EmployeesDepartments.DAL.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace EmployeesDepartments.DAL.Repository
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
                    Value = workingRate.workPosition.name
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
                        workPositions.Add(new WorkingRate()
                        {
                            id = reader.GetInt32(2),
                            department = new Department() { name = reader.GetString(0) },
                            workPosition = new WorkPosition() { name = reader.GetString(1) }
                        });

                    }
                }
                reader.Close();
            }

            return workPositions;
        }

        public List<Department> GetDepartmentsWithChief()
        {
            string sqlExpression = "GetDepartmentsWithChief";
            List<Department> departments = new List<Department>();
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
                        departments.Add(new Department()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            workingRates = new List<WorkingRate>() { new WorkingRate() { employeeWorkingRates = new List<EmployeeWorkingRate>()
                              { new EmployeeWorkingRate() { employee = new Employee() { name = reader.GetSqlString(2).ToString() } } } } }
                        });
                    }
                }
                reader.Close();
            }
            return departments;
        }

        public List<Employee> GetEmpoyeesByDepartmentId(Department department)
        {
            string sqlExpression = "GetEmpoyeesByDepartmentId";

            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[1];
                sqlParameters[0] = new SqlParameter
                {
                    ParameterName = "@departmentID",
                    Value = department.id
                };

                foreach (var sqlParameter in sqlParameters)
                {
                    command.Parameters.Add(sqlParameter);
                }
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employees.Add(new Employee()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            email = reader.GetString(2)
                        });
                    }
                }
                reader.Close();
            }
            return employees;
        }

        public List<WorkingRate> GetFreeRates()
        {
            string sqlExpression = "GetFreeRates";
            List<WorkingRate> workingRates = new List<WorkingRate>();
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
                        workingRates.Add(new WorkingRate()
                        {
                            department = new Department() { name = reader.GetString(0), },
                            workPosition = new WorkPosition() { name = reader.GetString(1) },
                            employeeWorkingRates = new List<EmployeeWorkingRate>() { new EmployeeWorkingRate() { halfRate = reader.GetBoolean(2) } }
                        });
                    }
                }
                reader.Close();
            }
            return workingRates;
        }

        public void EditEmpoyeeById(Employee employee)
        {
            string sqlExpression = "UpdateEmpoyeeById";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = employee.id
                };
                sqlParameters[1] = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = employee.name
                };
                sqlParameters[2] = new SqlParameter
                {
                    ParameterName = "@email",
                    Value = employee.email
                };


                foreach (var sqlParameter in sqlParameters)
                {
                    command.Parameters.Add(sqlParameter);
                }

                command.ExecuteScalar();
            }
        }
        public void EditWorkingRates(WorkingRate workingRate)
        {
            string sqlExpression = "EditWorkingRates";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[4];
                sqlParameters[0] = new SqlParameter
                {
                    ParameterName = "@namePosition",
                    Value = workingRate.workPosition.name
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
                sqlParameters[3] = new SqlParameter
                {
                    ParameterName = "@idWorkingRates",
                    Value = workingRate.id
                };

                foreach (var sqlParameter in sqlParameters)
                {
                    command.Parameters.Add(sqlParameter);
                }

                command.ExecuteScalar();
            }
        }

        public List<Department> GetAllDepartments()
        {
            string sqlExpression = "GetAllDepartments";
            List<Department> departments = new List<Department>();
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
                        departments.Add(new Department()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                        });
                    }
                }
                reader.Close();
            }
            return departments;
        }

        public List<Employee> GetAllEmployees()
        {
            string sqlExpression = "GetAllEmployees";
            List<Employee> employees = new List<Employee>();
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
                        employees.Add(new Employee()
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            email = reader.GetString(2),
                        });
                    }
                }
                reader.Close();
            }
            return employees;
        }
    }
}
