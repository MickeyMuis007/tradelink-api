using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tradelink.Domain.AggregateModels.RequestAggregate;

namespace Tradelink.Persistence.Configuration
{
  public class RequestConfiguration : IEntityTypeConfiguration<Request>
  {
    public void Configure(EntityTypeBuilder<Request> builder)
    {

      builder.ToTable("Request");
      builder.HasKey(e => e.Id);

      builder.HasMany(t => t.Transactions)
            .WithOne(t => t.Request)
            .HasForeignKey(t => t.RequestId)
            .OnDelete(DeleteBehavior.Restrict);

    }
  }
}