namespace Commify.TaxCalculator.Core.DataAccess.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> Get(Func<T, bool> expression);
        IEnumerable<T> GetAll();
        Task SaveAsync();
    }
}
