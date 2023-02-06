using WebApi2.Models.Entities;

namespace WebApi2.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<bool> PostEmployeeAsync(Employee employee);
        Task<bool> PutEmployeeAsync(Employee employee, int id);
        Task<bool> DeleteEmployeeAsync(Employee id);
        
    }
}
