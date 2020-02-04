using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;
using Tradelink.Domain.AggregateModels.RequestAggregate;
using System;

namespace Tradelink.Domain.AggregateModels.Builders
{
  public class TransactionBuilder : IBuild<TransactionBuilder, Transaction>
  {
    public string Type { get; private set; }
    public int Number { get; private set; }
    public DateTime Date { get; private set; }
    public Guid RequestId { get; private set; }
    public Request Request { get; private set; }

    public TransactionBuilder SetType(string type)
    {
      Type = type;
      return this;
    }

    public TransactionBuilder SetNumber (int number)
    {
      Number = number;
      return this;
    }

    public TransactionBuilder SetDate (DateTime date)
    {
      Date = date;
      return this;
    }

    public TransactionBuilder SetRequestId (Guid requestId)
    {
      RequestId = requestId;
      return this;
    }

    public TransactionBuilder setRequest(Request request)
    {
      Request = request;
      return this;
    }

    public TransactionBuilder Copy(Transaction transaction)
    {
      Type = transaction.Type;
      Number = transaction.Number;
      Date = transaction.Date;
      RequestId = transaction.RequestId;
      Request = transaction.Request;
      return this;
    }

    public Transaction Build()
    {
      return new Transaction(this);
    }
  }
}