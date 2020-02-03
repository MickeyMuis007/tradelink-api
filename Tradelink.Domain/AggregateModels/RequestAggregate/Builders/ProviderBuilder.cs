using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;
using System;

namespace Tradelink.Domain.AggregateModels.Builders
{
  public class ProviderBuilder : IBuild<ProviderBuilder, Provider>
  {
    public string Name { get; private set; }
    public Guid ContactId { get; private set; }
    public Contact Contact { get; private set; }

    public ProviderBuilder Copy(Provider provider)
    {
      Name = provider.Name;
      ContactId = provider.ContactId;
      Contact = provider.Contact;
      return this;
    }

    public Provider Build()
    {
      return new Provider(this);
    }
  }
}