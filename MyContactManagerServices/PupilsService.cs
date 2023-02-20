using ContactWebModels;
using MyContactManagerServices.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyContactManagerServices
{
    public class PupilsService : IPupilsService
  {
    private readonly IPupilsService _pupilsService;

    public PupilsService(IPupilsService pupilService)
    {
      _pupilsService = pupilService;
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

    public Pupil GetById(int id)
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

    public void Update(Pupil entity)
    {
      throw new NotImplementedException();
    }

    

    /*  public Pupil GetPupilById(int id)
      {
        return _pupilsService.GetById(id);
      }

      public void AddPupil(Pupil pupil)
      {
        _pupilsService.Add(pupil);
      }

      public void UpdatePupil(Pupil pupil)
      {
        _pupilsService.Update(pupil);
      }

      public void DeletePupil(Pupil pupil)
      {
        _pupilsService.Delete(pupil);
      }*/
  }

}
