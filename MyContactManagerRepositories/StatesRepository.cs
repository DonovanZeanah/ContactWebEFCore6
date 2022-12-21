using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using MyContactManagerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
  public class StatesRepository : IStatesRepository
  {
    private readonly MyContactManagerDbContext _context;

    public StatesRepository(MyContactManagerDbContext context)
    {
      _context = context;
    }
    
    public async Task<List<State>> GetAllAsync()
    {
      var allStatesData = await _context.States.OrderBy(x => x.Name).ToListAsync();
      return allStatesData;
    }

    public async Task<State> GetAsync(int id)
    {
      var state = await _context.States.SingleOrDefaultAsync(x => x.Id == id);
      return state;
    }
    public async Task<int> AddOrUpdateAsync(State state)
    {
      if (state.Id == 0)
      {
        return await Insert(state);
      }
      return await Update(state);
    }

    private async Task<int> Insert(State state)
    {
      await _context.States.AddAsync(state);
      await _context.SaveChangesAsync();
      return state.Id;
    }
    private async Task<int> Update(State state)
    {
      var existingState = await _context.States.SingleOrDefaultAsync(x => x.Id == state.Id);
      if(existingState == null)
      {
        throw new Exception("state not found homeboia");
      }
      existingState.Name = state.Name;
      existingState.Abbreviation = state.Abbreviation;
      await _context.SaveChangesAsync();
      return existingState.Id;

    }

    public async Task<bool> ExistsAsync(int id)
    {
      return await _context.States.AnyAsync(x => x.Id == id);

    }


    public async Task<int> DeleteAsync(int id)
    {
      var stateToDelete = await GetAsync(id);
      try
      {
        _context.Remove(stateToDelete);
        _context.SaveChanges();
        return id;
      }
      catch
      {
        return 0;
      }
    }
      
    

    public async Task<int> DeleteAsync(State state)
    {
      return await DeleteAsync(state.Id);
    }

  }
}
