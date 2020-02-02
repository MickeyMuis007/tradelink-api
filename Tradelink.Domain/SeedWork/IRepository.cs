using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tradelink.Domain.SeedWork
{
  public interface IRepository<TEntity, TId> where TEntity : class , IEntity
  {
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById();
    Task Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
  }
}