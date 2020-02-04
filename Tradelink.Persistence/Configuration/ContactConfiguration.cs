using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;

namespace Tradelink.Persistence.Configuration
{
  public class ContactConfiguration : IEntityTypeConfiguration<Contact>
  {
    public void Configure(EntityTypeBuilder<Contact> builder)
    {

      builder.ToTable("Contact");
      builder.HasKey(e => e.Id);

      builder.HasMany(t => t.Providers)
            .WithOne(t => t.Contact)
            .HasForeignKey(t => t.ContactId)
            .OnDelete(DeleteBehavior.Restrict);

    }
  }
}