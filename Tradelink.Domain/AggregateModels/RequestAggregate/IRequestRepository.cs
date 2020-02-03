using System;
using Tradelink.Domain.SeedWork;

namespace Tradelink.Domain.AggregateModels.RequestAggregate
{
  public interface IRequestRepository : IRepositoryWrite<Request, Guid>, IRepositoryRead<Request, Guid>
  {
    
  }
}