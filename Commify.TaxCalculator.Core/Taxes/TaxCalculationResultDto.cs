namespace Commify.TaxCalculator.Core.Taxes
{
    public  class TaxCalculationResultDto
    {
        public decimal AnualGrossSalary { get; set; }
        public decimal MonthlyGrossSalary { get; set; }
        public decimal AnualNetSalary { get; set; }
        public decimal MonthlyNetSalary { get; set; }
        public decimal AnnualTaxToBePaid { get; set; }
        public decimal MonthlyTaxToBePaid { get; set; }
    }
}
