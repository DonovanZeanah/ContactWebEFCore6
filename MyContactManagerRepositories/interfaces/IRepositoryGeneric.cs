using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories.interfaces
{
  public interface IRepository<TEntity> where TEntity : class
  {
    Task<List<TEntity>> GetAllAsync(string userId);
   Task<TEntity> GetByIdAsync(int id, string userId);
    
    Task<int> AddOrUpdateAsync(TEntity e, string userId);
    
    Task<int> Deleteasync(TEntity e, string userId);
    Task<int> DeleteAsync(int id, string userId);
    Task<List<TEntity>> GetByIdAsync(int id);
  }
}
