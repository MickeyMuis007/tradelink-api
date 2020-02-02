using System.Threading.Tasks;
using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.RequestAggregate;
using Tradelink.Persistence.Context;
using Tradelink.Implementations.Repositories.RequestRepo;

namespace Tradelink.Implementations.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private TradelinkContext _db;
    private IRequestRepository _requestRepository;

    public UnitOfWork(TradelinkContext db)
    {
      _db = db;
    }

    public IRequestRepository RequestRepository {
      get
      {
        return _requestRepository = _requestRepository ?? new RequestRepository(_db);
      }
    }

    public async Task SaveAsync()
    {
      await _db.SaveChangesAsync();
    }
  }
}