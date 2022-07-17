using Commify.TaxCalculator.Core.DataAccess.Models;
using Commify.TaxCalculator.Core.DataAccess.UnitOfWork;

namespace Commify.TaxCalculator.Core.Taxes
{
    public class TaxService : ITaxService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaxService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public TaxCalculationResultDto CalculateTax(decimal grossAnualSalary)
        {
            decimal totalTaxesToBePaid = 0;
            decimal totalTaxedSalary = 0;

            //TODO: Implement caching and get the tax band values for cache
            var taxBands = _unitOfWork.GetRepository<TaxBand>().GetAll().OrderBy(x => x.SalaryLowerLimit);
            if (taxBands == null || taxBands.Any() == false)
            {
                throw new InvalidOperationException($"No tax bands configured!");
            }

            foreach (var taxband in taxBands)
            {
                if (totalTaxedSalary >= grossAnualSalary)
                {
                    break;
                }

                if (taxband.SalaryUpperLimit != null)
                {
                    var taxableSalaryForTaxBand = Math.Min(taxband.SalaryUpperLimit.Value - taxband.SalaryLowerLimit, grossAnualSalary - taxband.SalaryLowerLimit);
                    var taxToBePaidForTaxBand = (taxableSalaryForTaxBand * taxband.TaxRate) / 100;
                    totalTaxesToBePaid += taxToBePaidForTaxBand;
                    totalTaxedSalary += taxableSalaryForTaxBand;
                }
                else
                {
                    var taxableSalaryForTaxBand = grossAnualSalary - totalTaxedSalary;
                    var taxToBePaidForTaxBand = (taxableSalaryForTaxBand * taxband.TaxRate) / 100;
                    totalTaxesToBePaid += taxToBePaidForTaxBand;
                    totalTaxedSalary += taxableSalaryForTaxBand;
                }
            }

            var result = new TaxCalculationResultDto()
            {
                AnualGrossSalary = decimal.Round(grossAnualSalary, 2, MidpointRounding.AwayFromZero),
                MonthlyGrossSalary = decimal.Round(grossAnualSalary / 12, 2, MidpointRounding.AwayFromZero),
                AnnualTaxToBePaid = decimal.Round(totalTaxesToBePaid, MidpointRounding.AwayFromZero),
                MonthlyTaxToBePaid = decimal.Round(totalTaxesToBePaid / 12, 2, MidpointRounding.AwayFromZero),
                AnualNetSalary = decimal.Round(grossAnualSalary - totalTaxesToBePaid, MidpointRounding.AwayFromZero),
                MonthlyNetSalary = decimal.Round((grossAnualSalary - totalTaxesToBePaid) / 12, MidpointRounding.AwayFromZero)
            };

            return result;
        }
    }
}
