using System;
using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.Builders;

namespace Tradelink.Domain.AggregateModels.RequestAggregate
{
  public class Request : Entity<Guid>, IAggregateRoot
  {
    public int Number { get; private set; }
    public DateTime Date { get; private set; }
    public bool Active { get; private set; }

    public Request(RequestBuilder builder) {
      
    }

  }
}