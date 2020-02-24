using System;
using System.Collections.Generic;
using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.RequestAggregate;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;


namespace Tradelink.Domain.AggregateModels.Builders
{
  public class RequestBuilder: IBuild<RequestBuilder, Request> {
    public int Number { get; private set; }
    public DateTime Date { get; private set; }
    public bool Active { get; private set; }

    public Provider provider { get; private set; }
    public IEnumerable<Transaction> Transactions { get; private set; }

    public RequestBuilder() {
      Number = 0;
      Date = DateTime.MinValue;
      Active = false;
    }

    public RequestBuilder SetNumber(int number) {
      Number = number;
      return this;
    }

    public RequestBuilder SetDate (DateTime date) {
      Date = date;
      return this;
    }

    public RequestBuilder SetActive (bool active) {
      Active = active;
      return this;
    }

    public RequestBuilder Copy(Request request) {
      Number = request.Number;
      Date = request.Date;
      Active = request.Active;
      return this;
    }

    public Request Build()
    {
      return new Request(this);
    }
  }
}