using ContactWebModels;
using MyContactManagerServices.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerServices
{
  public class LecturesService : ILecturesService
  {
    private readonly ILecturesService _LectureService;
    public LecturesService(ILecturesService LectureService)
    {
      _LectureService = LectureService;

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

    public Task<IEnumerable<Lecture>> GetAll()
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
