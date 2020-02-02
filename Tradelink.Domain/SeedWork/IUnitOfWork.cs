using Tradelink.Domain.AggregateModels.RequestAggregate;
using System.Threading.Tasks;

namespace Tradelink.Domain.SeedWork
{
  public interface IUnitOfWork
  {
    IRequestRepository RequestRepository { get; }
    Task SaveAsync();
  }
}