using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerServices
{
  public class SupplysService : ISupplysService
  {
    private ISupplysRepository _repository;
    public SupplysService(ISupplysRepository repository)
    {
      _repository = repository;
    }

    /*public async Task<List<Supply>> GetAllAsync(string itemId)
    {
      var supplys = await _context.Supplys
                      .Include(x => x.ItemId)
                      .AsNoTracking()
                      .Where(x => x.ItemId.ToUpper() == itemId.ToUpper())
                      .OrderBy(x => x.ItemName)
                      .ToListAsync();
      return supplys;
    }*/
    
    public async Task<List<Supply>> GetAllAsync(string itemId)
    {
      var data = await _repository.GetAllAsync(string itemId);
      return data;
    }

    public Task<Supply> GetAsync(int id, string itemId)
    {
      throw new NotImplementedException();
    }
    public Task<int> Add(Supply itemId, string categoryId, int quantity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> IsStockLow(int id, string itemId)
    {
      throw new NotImplementedException();
    }

    public Task<int> Subtract(Supply itemId, string categoryId, int quantity)
    {
      throw new NotImplementedException();
    }
  }

    public interface ISupplysRepository
    {
        Task GetAllAsync(string itemId);
    }
}
