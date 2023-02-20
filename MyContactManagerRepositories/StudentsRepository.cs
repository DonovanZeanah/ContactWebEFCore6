using ContactWebModels;
using MyContactManagerRepositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
  public class StudentsRepository : IStudentsRepository
  {
    public Task<int> AddOrUpdateAsync(Student e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> Deleteasync(Student e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Student>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public Task<Student> GetByIdAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Student>> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
