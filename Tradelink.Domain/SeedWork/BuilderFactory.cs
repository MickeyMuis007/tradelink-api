using System;

namespace Tradelink.Domain.SeedWork
{
  public class BuilderFactory <TBuilder> where TBuilder : class, IBuilder
  {
    public static TBuilder Create()
    {
      return (TBuilder)Activator.CreateInstance(typeof(TBuilder));
    }
  }
}