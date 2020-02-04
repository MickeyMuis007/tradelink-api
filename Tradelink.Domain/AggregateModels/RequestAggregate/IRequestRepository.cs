using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tradelink.Domain.SeedWork;

namespace Tradelink.Domain.AggregateModels.RequestAggregate
{
  public interface IRequestRepository : IRepositoryWrite<Request, Guid>, IRepositoryRead<Request, Guid>
  {
    Task<IEnumerable<Request>> GetAllInclude();
  }
}