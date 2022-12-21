using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
  public interface IContactsRepository
  {
    Task<List<State>> GetAllAsync();
    Task<State> GetAsync(int id);
    Task<int> AddOrUpdateAsync(Contact contact);
    Task<int> DeleteAsync(int id);
    Task<int> DeleteAsync(Contact contact);
    Task<bool> ExistsAsync(int id);
  }
}
