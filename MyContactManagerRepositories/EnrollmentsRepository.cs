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
  public class EnrollmentsRepository :  IEnrollmentsRepository
  {
    private readonly MyContactManagerDbContext _context;

    public EnrollmentsRepository(MyContactManagerDbContext context)
    {
      _context = context;
    }

    public void Add(Enrollment entity)
    {
      _context.Enrollments.Add(entity);
      _context.SaveChanges();
    }

    public Task<int> AddOrUpdateAsync(Enrollment e, string userId)
    {
      throw new NotImplementedException();
    }

    public void Delete(Enrollment entity)
    {
      _context.Enrollments.Remove(entity);
      _context.SaveChanges();
    }

    public Task<int> Deleteasync(Enrollment e, string userId)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id, string userId)
    {
      throw new NotImplementedException();
    }

    public Enrollment Get(int id)
    {
      return _context.Enrollments.Find(id);
    }

    public IEnumerable<Enrollment> GetAll()
    {
      return _context.Enrollments.ToList();
    }

    public Task<List<Enrollment>> GetAllAsync(string userId)
    {
      throw new NotImplementedException();
    }

    public Task<List<Enrollment>> GetById(int id)
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

    public void Update(Enrollment dbEntity, Enrollment entity)
    {
      dbEntity.LectureId = entity.LectureId;
      dbEntity.PupilId = entity.PupilId;
      dbEntity.PupilId = entity.PupilId;
      _context.SaveChanges();
    }

    public void Update(Enrollment entity)
    {
      throw new NotImplementedException();
    }

    
  }
 
}
