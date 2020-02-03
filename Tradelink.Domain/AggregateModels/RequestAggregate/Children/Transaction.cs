using System;
using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.Builders;

namespace Tradelink.Domain.AggregateModels.RequestAggregate.Children
{
  public class Transaction : Entity<Guid>, IEntity
  {
    public string Type { get; private set; }
    public int Number { get; private set; }
    public DateTime Date { get; private set; }
    public Guid RequestId { get; private set; }

    private Transaction() { }

    public Transaction(TransactionBuilder builder)
    {
      Type = builder.Type;
      Number = builder.Number;
      Date = builder.Date;
      RequestId = builder.RequestId;
    }
  }
}