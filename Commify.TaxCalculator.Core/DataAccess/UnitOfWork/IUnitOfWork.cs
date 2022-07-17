using Commify.TaxCalculator.Core.DataAccess.Repository;

namespace Commify.TaxCalculator.Core.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity: class;

        Task<int> SaveAsync();
        void Dispose();
    }
}
