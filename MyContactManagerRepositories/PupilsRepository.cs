using ContactWebModels;
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
  public class PupilsRepository : IPupilsRepository //IRepository<Pupil>, 
  {
    public PupilsRepository(MyContactManagerDbContext dbContext) 
    {
    }

    public Task<int> AddOrUpdateAsync(Pupil e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> Deleteasync(Pupil e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Pupil>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<List<Pupil>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public Task<Pupil> GetByIdAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Pupil>> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
