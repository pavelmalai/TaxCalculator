using Commify.TaxCalculator.Core.DataAccess.Repository;
using Commify.TaxCalculator.Core.DataAccess.UnitOfWork;
using Commify.TaxCalculator.Infrastructure.Contexts;
using Commify.TaxCalculator.Infrastructure.DataAccess.Repository;

namespace Commify.TaxCalculator.Infrastructure.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly TaxCalculatorContext _context;

        public UnitOfWork(TaxCalculatorContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
