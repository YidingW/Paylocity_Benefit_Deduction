using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Domain;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IBenefitCostFactory _benefitCostFactory;

        public EmployeeDataService(EmployeeDbContext dbContext, IBenefitCostFactory benefitCostFactory)
        {
            _dbContext = dbContext;
            _benefitCostFactory = benefitCostFactory;
        }
        
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            return await _dbContext.Employees.Include(e=>e.Dependants).Select(e=>new EmployeeDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                NumberOfDependants = e.Dependants.Count
            }).ToListAsync();
        }

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var employee = await _dbContext.Employees.Include(e=>e.Dependants).FirstOrDefaultAsync(e=>e.Id == id);
            return new EmployeeDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Dependants = employee.Dependants,
                NumberOfDependants = employee.Dependants.Count,
                Paycheck = _benefitCostFactory.CalculatePaychecks(employee)
            };
        }

        public List<Dependant> GetDependants(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public async Task NewEmployee(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}