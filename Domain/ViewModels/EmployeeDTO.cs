using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class EmployeeDTO
    {        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int NumberOfDependants { get; set; }

        public decimal TotalBenefitCost { get; set; }
        public List<Dependant> Dependants { get; set; }
        
        public Paycheck Paycheck { get; set; }
    }
}