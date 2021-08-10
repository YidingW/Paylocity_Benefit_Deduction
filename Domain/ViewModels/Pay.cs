namespace Domain.ViewModels
{
    public class Pay
    {
        public int PayNum { get; set; }
        
        public decimal PayBeforeCost { get; set; }
        public decimal BenefitCost { get; set; }
        
        public decimal PayAfterCost { get; set; }
    }
}