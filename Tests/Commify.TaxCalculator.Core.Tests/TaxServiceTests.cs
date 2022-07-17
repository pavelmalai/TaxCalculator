using Commify.TaxCalculator.Core.DataAccess.Models;
using Commify.TaxCalculator.Core.DataAccess.Repository;
using Commify.TaxCalculator.Core.DataAccess.UnitOfWork;
using Commify.TaxCalculator.Core.Taxes;
using Moq;

namespace Commify.TaxCalculator.Core.Tests
{
    [TestClass]
    public class TaxServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OnCalculateTax_WhenNoTaxBandsConfigured_ShouldThrowException()
        {
            //arrange
            var taxBandRepositoryMock = new Mock<IGenericRepository<TaxBand>>();
            IEnumerable<TaxBand> taxbands = new List<TaxBand>();
            taxBandRepositoryMock.Setup(x => x.GetAll()).Returns(taxbands);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.GetRepository<TaxBand>()).Returns(taxBandRepositoryMock.Object);

            TaxService taxService = new TaxService(unitOfWorkMock.Object);

            //act
            var result = taxService.CalculateTax(10000);

            //assert
        }

        //TODO: Use a wider range of test values
        [TestMethod]
        public void OnCalculateTax_WhenPositiveValue_ShouldCalculateTax()
        {
            //arrange
            var taxBandRepositoryMock = new Mock<IGenericRepository<TaxBand>>();
            IEnumerable<TaxBand> taxbands = new List<TaxBand>() {  new TaxBand
                {
                    Id = Guid.NewGuid(),
                    Name = "TaxBandA",
                    SalaryLowerLimit = 0,
                    SalaryUpperLimit = 5000,
                    TaxRate = 0
                },
                new TaxBand
                {
                    Id = Guid.NewGuid(),
                    Name = "TaxBandB",
                    SalaryLowerLimit = 5000,
                    SalaryUpperLimit = 20000,
                    TaxRate = 20
                },
                new TaxBand
                {
                    Id = Guid.NewGuid(),
                    Name = "TaxBandC",
                    SalaryLowerLimit = 20000,
                    SalaryUpperLimit = null,
                    TaxRate = 40
                }};
            taxBandRepositoryMock.Setup(x => x.GetAll()).Returns(taxbands);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.GetRepository<TaxBand>()).Returns(taxBandRepositoryMock.Object);

            TaxService taxService = new TaxService(unitOfWorkMock.Object);

            //act
            var result = taxService.CalculateTax(10000);

            //assert
            Assert.AreEqual(result.AnnualTaxToBePaid, 1000);
            Assert.AreEqual(result.AnualNetSalary, 9000);
            Assert.AreEqual(result.MonthlyGrossSalary, (decimal)833.33);
            Assert.AreEqual(result.MonthlyNetSalary, 750);
            Assert.AreEqual(result.MonthlyTaxToBePaid, (decimal)83.33);
        }

        //TODO: implement other test cases
    }
}