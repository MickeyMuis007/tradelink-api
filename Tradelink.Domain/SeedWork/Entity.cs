using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;

namespace Tradelink.Domain.SeedWork
{
  public abstract class Entity<TId> : IEquatable<Entity<TId>>
  {
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
      if (object.Equals(id, default(TId))) 
      {
        throw new ArgumentException("The Id Cannot be the type's default value.", "id");
      }
      Id = id;
    }

    protected Entity() { }

    public override bool Equals(object otherObject) 
    {
      var entity = otherObject as Entity<TId>;
      if (entity != null) 
      {
        return Equals(entity);
      }
      return base.Equals(otherObject);
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public bool Equals(Entity<TId> other) {
      if (other == null) 
      {
        return false;
      }
      return true;
    }
  }
}