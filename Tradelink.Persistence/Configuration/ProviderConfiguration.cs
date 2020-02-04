using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;

namespace Tradelink.Persistence.Configuration
{
  public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
  {
    public void Configure(EntityTypeBuilder<Provider> builder)
    {

      builder.ToTable("Provider");
      builder.HasKey(e => e.Id);
    }
  }
}