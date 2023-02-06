using Dapper;
using System;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using WebApi2.Models.Entities;

namespace WebApi2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            string sql = @"
                            SELECT
	                            pp.BusinessEntityID as Id,
	                            pp.FirstName,
	                            pp.MiddleName,
	                            pp.LastName,
	                            he.JobTitle,
	                            he.BirthDate,
	                            he.MaritalStatus,
	                            he.Gender,
	                            pa.AddressLine1 as AddressLine,
	                            pa.City,
	                            ps.CountryRegionCode,
	                            ps.Name as State,
	                            pc.Name as Country,
	                            pa.PostalCode
                            FROM [Person].[Person] pp
                            INNER JOIN [HumanResources].[Employee] he 
	                            ON pp.BusinessEntityID = he.BusinessEntityID
                            INNER JOIN [Person].[BusinessEntityAddress] pb
	                            ON pb.BusinessEntityID = pp.BusinessEntityID
                            INNER JOIN [Person].[Address] pa
	                            ON pa.AddressID = pb.AddressID
                            INNER JOIN [Person].[StateProvince] ps
	                            ON ps.StateProvinceID = pa.StateProvinceID
                            INNER JOIN [Person].[CountryRegion] pc
	                            ON pc.CountryRegionCode = ps.CountryRegionCode
                            ";

            using (var con = new SqlConnection(connectionString))
            {
                return await con.QueryAsync<Employee>(sql);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var sql = @"    SELECT
                                pp.BusinessEntityID as Id,
	                            pp.FirstName,
	                            pp.MiddleName,
	                            pp.LastName,
	                            he.JobTitle,
	                            he.BirthDate,
	                            he.MaritalStatus,
	                            he.Gender,
	                            pa.AddressLine1 as AddressLine,
	                            pa.City,
	                            ps.CountryRegionCode,
	                            ps.Name as State,
	                            pc.Name as Country,
	                            pa.PostalCode
                            FROM[Person].[Person] pp
                            INNER JOIN[HumanResources].[Employee] he
                                ON pp.BusinessEntityID = he.BusinessEntityID
                            INNER JOIN[Person].[BusinessEntityAddress] pb
                                ON pb.BusinessEntityID = pp.BusinessEntityID
                            INNER JOIN[Person].[Address] pa
                                ON pa.AddressID = pb.AddressID
                            INNER JOIN[Person].[StateProvince] ps
                                ON ps.StateProvinceID = pa.StateProvinceID
                            INNER JOIN[Person].[CountryRegion] pc
                                ON pc.CountryRegionCode = ps.CountryRegionCode
                            WHERE 1=1
                                AND pp.BusinessEntityID = @Id";

            using(var con = new SqlConnection(connectionString)) 
            {
                return await con.QueryFirstOrDefaultAsync<Employee>(sql, new { id = id});
            }
        }
        public Task<bool> PostEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutEmployeeAsync(Employee employee, int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEmployeeAsync(Employee id)
        {
            throw new NotImplementedException();
        }
    }
}
