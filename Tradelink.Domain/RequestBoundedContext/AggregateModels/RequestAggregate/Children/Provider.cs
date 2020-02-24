using Tradelink.Domain.SeedWork;
using System;
using Tradelink.Domain.AggregateModels.Builders;

namespace Tradelink.Domain.AggregateModels.RequestAggregate.Children
{
  public class Provider : Entity<Guid>, IEntity
  {
    public string Name { get; private set; }
    public Guid ContactId { get; private set; }
    public Contact Contact { get; private set; }

    private Provider() { }

    public Provider(ProviderBuilder builder)
    {
      Name = builder.Name;
      ContactId = builder.ContactId;
      Contact = builder.Contact;
    }
  }
}