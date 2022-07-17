namespace Commify.TaxCalculator.Core.DataAccess.Models
{
    public class TaxBand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SalaryLowerLimit { get; set; }
        public int? SalaryUpperLimit { get; set; }
        public int TaxRate { get; set; }
    }
}
