using Microsoft.EntityFrameworkCore;
using MyContactManagerData;
using MyContactManagerRepositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly MyContactManagerDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(MyContactManagerDbContext dbContext)
    {
      _context = dbContext;
      _dbSet = _context.Set<TEntity>();
    }

    public TEntity GetById(int id)
    {
      return _dbSet.Find(id);
    }
    
    public IEnumerable<TEntity> GetAll()
    {
      return _dbSet.ToList();
    }

    public void Add(TEntity entity)
    {
      _dbSet.Add(entity);
      _context.SaveChanges();
    }

    public void Update(TEntity entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
      _dbSet.Remove(entity);
      _context.SaveChanges();
    }

    public Task<List<TEntity>> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<TEntity>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

  

    public Task<int> AddOrUpdateAsync(TEntity e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> Deleteasync(TEntity e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }
  }
}
