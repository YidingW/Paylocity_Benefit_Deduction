namespace Business
{
    public interface IStrategy
    {
        decimal EmployeeCostBase { get; }
        float DiscountRate { get; }
        int NumberOfPaycheck { get; }
        decimal EmployeePay { get; }
        decimal DependantBenefitCost { get; }
        decimal RateByName(string firstName, string lastName);
    }
}