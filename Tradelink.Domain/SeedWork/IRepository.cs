using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tradelink.Domain.SeedWork
{
  public interface IRepository<TEntity, TId>: IRepositoryRead<TEntity, TId>, IRepositoryWrite<TEntity, TId> where TEntity : class , IAggregateRoot
  {
   
  
  }
}