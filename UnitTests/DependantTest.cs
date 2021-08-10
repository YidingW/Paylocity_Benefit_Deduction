using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class DependantTest
    {
        public DependantTest()
        {
            
        }

        [Fact]
        public async Task Should_Return_All_Dependants_Give_EmployeeId()
        {
            var context = await GetDatabaseContext();
            var dataService = new DependantDataService(context);
        }
        
        private static async Task<EmployeeDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            
            var databaseContext = new EmployeeDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Employees.AddRangeAsync(new List<Employee>
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe" },
            });
            await databaseContext.Dependants.AddRangeAsync(new List<Dependant>
            {
                new() {Id = 1, EmployeeId = 1, Type = "Spouse", FirstName = "Dependant", LastName = "Test"},
                new() {Id = 2, EmployeeId = 1, Type = "Child", FirstName = "Aello", LastName = "World"}
            });
            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }
    }
}