namespace Tradelink.Domain.SeedWork
{
  public interface IBuild<TBuilder, TBuild> : IBuilder where TBuilder : class, IBuilder where TBuild : class, IEntity
  {
    TBuilder Copy(TBuild copy);
    TBuild Build();
  }
}