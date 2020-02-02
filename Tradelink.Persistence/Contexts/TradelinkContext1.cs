// using Microsoft.EntityFrameworkCore;
// using Tradelink.Domain.AggregateModels.RequestAggregate;
// using System.Collections.Generic;

// namespace Tradelink.Persistence.Contexts
// {
//   public class TradelinkContext : DbContext
//   {
//     public TradelinkContext(DbContextOptions<TradelinkContext> options) : base(options)
//     {

//     }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//       // optionsBuilder.UseSqlServer("server=localhost;database=library;user=root;password=password");
//       // if (!optionsBuilder.IsConfigured)
//       // {
//       //   optionsBuilder.UseMySql("server=localhost;database=eazi4u;user=root;pwd=password");
//       // }
//     }
//     public DbSet<Request> Requests { get; set; }
//   }
// }