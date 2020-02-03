using System;
using System.Collections.Generic;
using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.Builders;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;

namespace Tradelink.Domain.AggregateModels.RequestAggregate
{
  public class Request : Entity<Guid>, IAggregateRoot
  {
    public int Number { get; private set; }
    public DateTime Date { get; private set; }
    public bool Active { get; private set; }
    public Provider provider { get; private set; }
    public IEnumerable<Transaction> Transactions { get; private set; }

    public Request(RequestBuilder builder) {
      Number = builder.Number;
      Date = builder.Date;
      Active = builder.Active;
    }

    private Request() { }
  }
}