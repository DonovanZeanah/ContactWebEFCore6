using ContactWebModels;
using MyContactManagerServices.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerServices
{
  public class EnrollmentsService : IEnrollmentService
  {
    public Task<int> AddOrUpdateAsync(Enrollment e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> Deleteasync(Enrollment e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Enrollment>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public Task<Enrollment> GetByIdAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Enrollment>> GetByIdAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
