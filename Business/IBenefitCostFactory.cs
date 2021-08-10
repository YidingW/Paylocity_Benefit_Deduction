using Domain;
using Domain.ViewModels;

namespace Business
{
    public interface IBenefitCostFactory
    {
        Paycheck CalculatePaychecks(Employee employee);
    }
}