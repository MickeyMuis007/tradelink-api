using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tradelink.Domain.AggregateModels.RequestAggregate;
using Tradelink.Domain.AggregateModels.RequestAggregate.Children;
using Tradelink.Persistence.Configuration;

namespace Tradelink.Persistence.Context
{
    public partial class TradelinkContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TradelinkContext()
        {
        }

        public TradelinkContext(DbContextOptions<TradelinkContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=tradelink1;user=root;pwd=password", x => x.ServerVersion("5.7.29-mysql"));
                // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Tradelink;Integrated Security=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }
    }
}
