using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tradelink.Domain.SeedWork
{
  public interface IRepositoryRead<TEntity, TId> where TEntity : class , IEntity
  {
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> GetById(TId id);
  }
}