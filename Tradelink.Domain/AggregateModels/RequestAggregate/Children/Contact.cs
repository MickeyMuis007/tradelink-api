using Tradelink.Domain.SeedWork;
using System;
using Tradelink.Domain.AggregateModels.Builders;

namespace Tradelink.Domain.AggregateModels.RequestAggregate.Children
{
  public class Contact : Entity<Guid>, IEntity
  {
    public string Name { get; private set; }
    public string TelephoneNumber { get; private set; }
    public string EmailAddress { get; private set; }

    private Contact() { }

    public Contact(ContactBuilder builder)
    {
      Name = builder.Name;
      TelephoneNumber = builder.TelephoneNumber;
      EmailAddress = builder.EmailAddress;
    }
  }
}