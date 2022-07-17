using Commify.TaxCalculator.Core.DataAccess.Repository;
using Commify.TaxCalculator.Infrastructure.Contexts;

namespace Commify.TaxCalculator.Infrastructure.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaxCalculatorContext _context;

        public GenericRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Get(Func<T, bool> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        //TO DO : implement other methods
    }
}
