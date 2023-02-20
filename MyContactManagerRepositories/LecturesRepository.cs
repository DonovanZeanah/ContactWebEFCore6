using ContactWebModels;
using MyContactManagerData;
using MyContactManagerRepositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
  public class LecturesRepository : ILecturesRepository //IRepository<Lecture>,
  {
    private readonly MyContactManagerDbContext _context;

    public LecturesRepository(MyContactManagerDbContext context)
    {
      _context = context;
    }

    public Task<int> AddOrUpdateAsync(Lecture e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> Deleteasync(Lecture e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Lecture>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public Task<Lecture> GetByIdAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Lecture>> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
