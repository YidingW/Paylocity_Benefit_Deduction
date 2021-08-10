using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class BenefitCostTest
    {
        private readonly BenefitCostFactory _benefitCostFactory;
        public BenefitCostTest()
        {
            _benefitCostFactory = new BenefitCostFactory(new DefaultPayStrategy());
        }
        [Fact]
        public async Task Should_Calculate_Cost_Use_Employee()
        {
            var context = await GetDatabaseContext();
            var employee = await context.Employees.Include(e => e.Dependants).SingleAsync(e => e.Id == 1);
            var paycheck = _benefitCostFactory.CalculatePaychecks(employee);
            
            Assert.Equal(2000, paycheck.TotalCost);
            Assert.Equal(52000, paycheck.TotalPay);
            Assert.Equal(50000, paycheck.TotalPayAfterCost);
        }
        
        [Fact]
        public async Task Should_Calculate_Discount_Cost_Use_Employee()
        {
            var context = await GetDatabaseContext();
            var employee = await context.Employees.Include(e => e.Dependants).SingleAsync(e => e.Id == 2);
            var paycheck = _benefitCostFactory.CalculatePaychecks(employee);
            
            Assert.Equal(900, paycheck.TotalCost);
        }

        [Fact]
        public async Task Should_Calculate_Accurate_BenefitCost_PerCheck()
        {
            var context = await GetDatabaseContext();
            var employee = await context.Employees.Include(e => e.Dependants).SingleAsync(e => e.Id == 1);
            var paycheck = _benefitCostFactory.CalculatePaychecks(employee);
            
            Assert.Equal(26, paycheck.Pays.Count);
            Assert.Equal(77, paycheck.Pays.First().BenefitCost);
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
                new() { Id = 2, FirstName = "Ashley", LastName = "Tulsa" }
            });
            await databaseContext.Dependants.AddRangeAsync(new List<Dependant>
            {
                new() {Id = 1, EmployeeId = 1, Type = "Spouse", FirstName = "Dependant", LastName = "Test"},
                new() {Id = 2, EmployeeId = 1, Type = "Child", FirstName = "Hello", LastName = "World"}
            });
            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }
    }
}