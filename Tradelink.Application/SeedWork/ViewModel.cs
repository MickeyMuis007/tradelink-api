using System;

namespace Tradelink.Application.SeedWork
{
  public abstract class ViewModel<TId> : IEquatable<ViewModel<TId>>
  {
    public TId Id { get; protected set; }

    protected ViewModel(TId id)
    {
      if (object.Equals(id, default(TId)))
      {
        throw new ArgumentException("The ID Cannot be the type's default value", "id");
      }
      Id = id;
    }

    protected ViewModel() { }

    public override bool Equals(object otherObj)
    {
      var entity = otherObj as ViewModel<TId>;
      if (entity != null)
      {
        return Equals(entity);
      }
      return base.Equals(otherObj);
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public bool Equals(ViewModel<TId> other)
    {
      if (other == null) {
        return false;
      }
      return Id.Equals(other.Id);
    }
  }
}