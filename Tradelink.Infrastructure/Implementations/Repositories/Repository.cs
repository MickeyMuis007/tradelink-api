using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Tradelink.Domain.SeedWork;
using Tradelink.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Tradelink.Implementations.Repositories
{
  public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IAggregateRoot
  {
    protected readonly TradelinkContext _db;

    public Repository(TradelinkContext db) 
    {
      _db = db;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
      return await _db.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(TId id)
    {
      return await _db.FindAsync<TEntity>(id);
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
      var t = await _db.AddAsync(entity);
      return entity;
    }

    public void Update(TEntity entity)
    {
      _db.Update(entity);
    }

    public void Delete(TEntity entity)
    {
      _db.Remove(entity);
    }
  }
}