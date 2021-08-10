using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
            
        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder);
        //     optionsBuilder.UseSqlite("Data Source=EmployeeBenefit.db");
        // }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependant> Dependants  { get; set; }
        
    }
}