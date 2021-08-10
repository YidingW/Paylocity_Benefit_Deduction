using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.ViewModels;

namespace Data
{
    public interface IEmployeeDataService
    {
        Task<List<EmployeeDTO>> GetAllEmployees();

        Task<EmployeeDTO> GetEmployee(int id);

        List<Dependant> GetDependants(int employeeId);
        Task NewEmployee(Employee employee);
    }
}