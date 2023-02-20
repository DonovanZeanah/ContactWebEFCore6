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
  public class MockPupilsRepository : IPupilsRepository
  {
    private readonly MyContactManagerDbContext _context;
    public MockPupilsRepository(MyContactManagerDbContext context)
    {
      _context = context;
    }
    public void Add(Pupil entity)
    {
      throw new NotImplementedException();
    }

    public Task<int> AddOrUpdateAsync(Pupil e, string userId)
    {
      throw new NotImplementedException();
    }

    public void Delete(Pupil entity)
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

    public IEnumerable<Pupil> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<List<Pupil>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public async Task<Pupil> GetByIdAsync(int id)
    {
      return await _context.Pupils
        .Include(x => x.Lectures)
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();
      
    }

    public async Task<Pupil> GetByIdAsync(int id, string userId)
    {
      var pupil = await _context.Pupils
        .Include(x => x.Lectures)
        .Where(x => x.UserId.ToUpper() == userId.ToUpper())
        .FirstOrDefaultAsync();
      return pupil;
    }

    public void Update(Pupil entity)
    {
      throw new NotImplementedException();
    }

    

    // Implement other methods from IStudentRepository interface
  }
}
