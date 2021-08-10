namespace Business
{
    public class DefaultPayStrategy : IStrategy
    {
        public decimal EmployeePay => 2000;
        public decimal DependantBenefitCost => 500;
        public decimal EmployeeCostBase => 1000;
        public float DiscountRate =>0.1f;
        public int NumberOfPaycheck => 26;

        public decimal RateByName(string firstName, string lastName)
        {
            return new decimal(firstName.ToUpper().StartsWith("A") || lastName.ToUpper().StartsWith("A")
                ? 1 - DiscountRate
                : 1);
        }
    }
}