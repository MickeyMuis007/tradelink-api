
using Tradelink.Domain.SeedWork;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;


namespace Tradelink.Domain.AggregateModels.Builders
{
  public class ContactBuilder : IBuild<ContactBuilder, Contact>
  {
     public string Name { get; private set; }
    public string TelephoneNumber { get; private set; }
    public string EmailAddress { get; private set; }

    public ContactBuilder SetName(string name)
    {
      Name = name;
      return this;
    }

    public ContactBuilder SetTelephoneNumber(string telepohoneNumber)
    {
      TelephoneNumber = telepohoneNumber;
      return this;
    }

    public ContactBuilder SetEmailAddress(string emailAddress)
    {
      EmailAddress = emailAddress;
      return this;
    }

    public ContactBuilder Copy(Contact contact)
    {
      return this;
    }

    public Contact Build() 
    {
      return new Contact(this);
    }
  }
}