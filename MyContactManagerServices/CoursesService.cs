using ContactWebModels;
using MyContactManagerServices.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerServices
{
  public class CoursesService : ICoursesService
  {
    public Task<int> AddOrUpdateAsync(Course e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> Deleteasync(Course e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Course>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public Task<Course> GetByIdAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Course>> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
