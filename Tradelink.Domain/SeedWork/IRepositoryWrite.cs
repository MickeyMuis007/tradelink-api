using System.Threading.Tasks;

namespace Tradelink.Domain.SeedWork
{
  public interface IRepositoryWrite<TEntity, TId> where TEntity : class , IAggregateRoot
  {
    Task<TEntity> Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TId id);
  }
}