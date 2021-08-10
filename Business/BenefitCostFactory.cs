using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.ViewModels;

namespace Business
{
    public class BenefitCostFactory : IBenefitCostFactory
    {
        private readonly IStrategy _payStrategy; 
        public BenefitCostFactory(IStrategy payStrategy)
        {
            _payStrategy = payStrategy;
        }
        
        public Paycheck CalculatePaychecks(Employee employee)
        {
            var employeeCost = _payStrategy.EmployeeCostBase * _payStrategy.RateByName(employee.FirstName, employee.LastName);
            var dependantCost = DependantCost(employee);

            var totalCost = employeeCost + dependantCost;

            var costPerCheck = decimal.Divide(totalCost, _payStrategy.NumberOfPaycheck);
            var roundCost = decimal.Round(costPerCheck, 2);
            var differenceToAddToFirstCheck = totalCost - roundCost * _payStrategy.NumberOfPaycheck;

            var pays = new List<Pay>
            {
                new()
                {
                    PayNum = 1,
                    PayBeforeCost = _payStrategy.EmployeePay,
                    BenefitCost = roundCost + differenceToAddToFirstCheck,
                    PayAfterCost = _payStrategy.EmployeePay - roundCost - differenceToAddToFirstCheck
                }
            };
            
            for (var i = 1; i < _payStrategy.NumberOfPaycheck; i++)
            {
                pays.Add(new Pay
                {
                    PayNum = i + 1,
                    PayBeforeCost = _payStrategy.EmployeePay,
                    BenefitCost = roundCost,
                    PayAfterCost = _payStrategy.EmployeePay - roundCost
                });
            }

            return new Paycheck
            {
                TotalPay = _payStrategy.EmployeePay * _payStrategy.NumberOfPaycheck,
                DependantBenefitCost = dependantCost,
                EmployeeBenefitCost = employeeCost,
                Pays = pays
            };
        }

        private decimal DependantCost(Employee employee)
            => employee.Dependants.Any()
                ? employee.Dependants.Sum(d => _payStrategy.DependantBenefitCost * _payStrategy.RateByName(d.FirstName, d.LastName))
                : 0;
        
    }
}