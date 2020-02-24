using System; 
using Tradelink.Domain.SeedWork;
namespace Tradelink.Domain.CheckinProcess.AggregateModels.CheckinAggregate
{
  public class Checkin : Entity<Guid>, IAggregateRoot
  {
    public Guid WaiterId { get; private set; }
    public Guid TableId { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime Date { get; private set; }
  }
}