namespace Commify.TaxCalculator.Core.Taxes
{
    public interface ITaxService
    {
        public TaxCalculationResultDto CalculateTax(decimal grossAnualSalary);
    }
}
