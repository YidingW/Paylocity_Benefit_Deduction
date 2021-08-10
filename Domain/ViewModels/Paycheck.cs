using System;
using System.Collections.Generic;
using Domain.ViewModels;

namespace Domain.ViewModels
{
    public class Paycheck
    {   
        public decimal TotalPay { get; set; }
        
        public decimal EmployeeBenefitCost { get; set; }
        
        public decimal DependantBenefitCost { get; set; }

        public decimal TotalCost => EmployeeBenefitCost + DependantBenefitCost;

        public decimal TotalPayAfterCost => TotalPay - TotalCost; 
        public List<Pay> Pays { get; set; }
    }
}
