using System.Threading.Tasks;
using Domain;

namespace Data
{
    public class DependantDataService : IDependantDataService
    {
        private readonly EmployeeDbContext _dbContext;

        public DependantDataService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddDependant(Dependant dependant)
        {
            await _dbContext.Dependants.AddAsync(dependant);
            await _dbContext.SaveChangesAsync();
        }
    }
}