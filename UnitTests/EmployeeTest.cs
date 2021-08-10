using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business;
using Data;
using Domain;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class EmployeeTest
    {
        private async Task<EmployeeDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new EmployeeDbContext(options);
            await databaseContext.Database.EnsureCreatedAsync();
            await databaseContext.Employees.AddRangeAsync(new List<Employee>
            {
                new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 2, FirstName = "Ashley", LastName = "Tulsa" }
            });
            await databaseContext.Dependants.AddRangeAsync(new List<Dependant>
            {
                new() { Id = 1, EmployeeId = 1, Type = "Spouse", FirstName = "Dependant", LastName = "Test" },
                new() { Id = 2, EmployeeId = 1, Type = "Child", FirstName = "Hello", LastName = "World" }
            });
            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }

        [Fact]
        public async void Should_GetAll_Return_AllEmployees()
        {
            var mockContext = await GetDatabaseContext();
            var employees = await new EmployeeDataService(mockContext, new BenefitCostFactory(new DefaultPayStrategy()))
                .GetAllEmployees();

            Assert.NotEmpty(employees);
            Assert.Equal(2, employees.Count);
        }

        [Fact]
        public async void Should_GetById_Return_SingleEmployee()
        {
            var mockContext = await GetDatabaseContext();

            var employee = await new EmployeeDataService(mockContext, new BenefitCostFactory(new DefaultPayStrategy()))
                .GetEmployee(1);

            Assert.NotNull(employee);
            Assert.Equal("John", employee.FirstName);
            Assert.NotEmpty(employee.Dependants);
            Assert.Equal(2, employee.Dependants.Count);
        }

        [Fact]
        public async void Should_SaveNewEmployee()
        {
            var mockContext = await GetDatabaseContext();

            var dataService = new EmployeeDataService(mockContext, new BenefitCostFactory(new DefaultPayStrategy()));
            await dataService.NewEmployee(new Employee { FirstName = "test", LastName = "Doe" });

            var employees = await dataService.GetAllEmployees();
            Assert.NotNull(employees);
            Assert.Equal(3, employees.Count);
        }

        [Fact]
        public async void Should_Return_EmployeeDetail_By_Id()
        {
            var mockContext = await GetDatabaseContext();

            var employee = await new EmployeeDataService(mockContext, new BenefitCostFactory(new DefaultPayStrategy()))
                .GetEmployee(2);

            Assert.IsType<EmployeeDTO>(employee);
            Assert.Equal("Ashley", employee.FirstName);
        }
    }
}