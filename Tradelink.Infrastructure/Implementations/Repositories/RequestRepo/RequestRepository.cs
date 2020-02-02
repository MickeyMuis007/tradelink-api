using System;
using Tradelink.Domain.AggregateModels.RequestAggregate;
using Tradelink.Persistence.Context;

namespace Tradelink.Implementations.Repositories.RequestRepo
{
  public class RequestRepository : Repository<Request, Guid>, IRequestRepository
  {
    public RequestRepository(TradelinkContext db) : base(db) { }
  }
}