using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;

namespace Tradelink.Persistence.Configuration
{
  public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
  {
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {

      builder.ToTable("Transaction");
      builder.HasKey(e => e.Id);

    }
  }
}