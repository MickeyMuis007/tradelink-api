using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tradelink.Domain.AggregateModels.RequestAggregate;
using Tradelink.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Tradelink.Implementations.Repositories.RequestRepo
{
  public class RequestRepository : Repository<Request, Guid>, IRequestRepository
  {
    public RequestRepository(TradelinkContext db) : base(db) { }

    public async Task<IEnumerable<Request>> GetAllInclude()
    {
      var results = await base._db.Requests.Include(t => t.Transactions).Include(t => t.Provider).ToListAsync();
      return results;
    }
  }
}