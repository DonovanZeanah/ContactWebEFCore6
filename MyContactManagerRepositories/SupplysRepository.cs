using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using MyContactManagerData;
using MyContactManagerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
  public class SupplysRepository : ISupplysRepository
  {
    private readonly MyContactManagerDbContext _context;
    private object itemId;

    public SupplysRepository(MyContactManagerDbContext context)
    {
      _context = context;
    }

    public async Task<List<Supply>> GetAllAsync(string itemName)
    {
      var items = await _context.Supplys
                      .Include(x => x.ItemId)
                      .AsNoTracking()
                      .Where(x => x.ItemName.ToUpper() == itemName.ToUpper())
                      .OrderBy(x => x.ItemName)
                      .ToListAsync();
      return items;
    }

    public async Task<Supply> GetAsync(int id, string itemName)
    {
      var supply = await _context.Supplys
                              .Include(x => x.ItemName)
                              .AsNoTracking()
                              .SingleOrDefaultAsync(x => x.Id == id && x.ItemName == itemName);
      return supply;
    }

    public async Task<int> AddAsync(Supply s, int id, string categoryId, int quantity)
    {
      if (s.Id > 0)
      {
        return await Update(s, itemId.ToString());
      }
      return await Insert(s, itemId.ToString());
    }

    private async Task GetExistingSupplyReference(Supply supply)
    {
      var existingSupply = await _context.Supplys.SingleOrDefaultAsync(x => x.Id == supply.Id);
      if (existingSupply is not null)
      {
        supply.ItemName = existingSupply.ToString();
      }
    }


    private async Task<int> Insert(Supply s, string itemId)
    {
      await GetExistingSupplyReference(s);
      await _context.Supplys.AddAsync(s);
      await _context.SaveChangesAsync();
      return s.Id;
    }




    private async Task<int> Update(Supply s, string itemId)
    {
      var existing = await _context.Supplys.SingleOrDefaultAsync(x => x.Id == s.Id && x.ItemId.ToString() == itemId);
      if (existing is null) throw new Exception("Supply not found");

      existing.ItemName = s.ItemName;
      //existing.
      //existing.UserId = c.UserId;

      await _context.SaveChangesAsync();
      return existing.Id;
    }

    public async Task<int> DeleteAsync(Supply s, string itemId)
    {
      return await DeleteAsync(s.Id, itemId);
    }

    public async Task<int> DeleteAsync(int id, string itemId)
    {
      var existingSupply = await _context.Supplys.SingleOrDefaultAsync(x => x.Id == id && x.ItemId.ToString() == itemId);
      if (existingSupply is null) throw new Exception("Could not delete supply due to unable to find matching supply");

      _context.Supplys.Remove(existingSupply);
      await _context.SaveChangesAsync();
      return id;
    }

    public async Task<bool> isStockLow(int id, int quantity)
    {
      var existingSupply = await _context.Supplys.SingleOrDefaultAsync(x => x.Id == id && x.Quantity == quantity);
      if (existingSupply.Quantity < 10)
      {
        throw new Exception("Need to restock");
      }
      return false; ;

    }

    public Task<int> AddAsync(Supply s, string categoryId, int quantity)
    {
      throw new NotImplementedException();
    }

    public Task<int> SubtractAsync(Supply s, string categoryId, int quantity)
    {
      throw new NotImplementedException();
    }

    public Task<bool> IsStockLow(int id, int quantity)
    {
      throw new NotImplementedException();
    }
  }
}
/*

Task<Supply> ISupplysRepository.GetAsync(int id, string itemId)
{
throw new NotImplementedException();
}

public Task<int> Add(Supply itemId, string categoryId, int quantity)
{
throw new NotImplementedException();
}

public Task<int> Subtract(Supply itemId, string categoryId, int quantity)
{
throw new NotImplementedException();
}

public Task<bool> IsStockLow(int id, string itemId)
{
throw new NotImplementedException();
}

public Task<int> SubtractAsync(Supply itemId, string categoryId, int quantity)
{
throw new NotImplementedException();
}

public Task<int> AddAsync(Supply s, string categoryId, int quantity)
{
throw new NotImplementedException();
}
}*/

