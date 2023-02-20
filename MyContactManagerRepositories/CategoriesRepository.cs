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
    public class CategoriesRepository : ICategoriesRepository
  {
    private readonly MyContactManagerDbContext _context;

    public CategoriesRepository(MyContactManagerDbContext context)
    {
      _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
    {
      var allCategoriesData = await _context.Categories.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
      return allCategoriesData;
    }

    public async Task<Category> GetAsync(int id)
    {
      var category = await _context.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
      return category;
    }

    public async Task<int> AddOrUpdateAsync(Category category)
    {
      if (category.Id > 0)
      {
        return await UpdateAsync(category);
      }
      return await InsertAsync(category);
    }
    
    private async Task<int> UpdateAsync(Category category)
    {
      var existingCategory = await _context.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);
      if (existingCategory is null) throw new Exception("Category not found");

      existingCategory.Name = category.Name;

      await _context.SaveChangesAsync();
      return category.Id;
    }

    private async Task<int> InsertAsync(Category category)
    {
      await _context.Categories.AddAsync(category);
      await _context.SaveChangesAsync();
      return category.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
      var existingCategory = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
      if (existingCategory is null) throw new Exception("Could not delete category due to unable to find matching category");

      _context.Categories.Remove(existingCategory);
      await _context.SaveChangesAsync();
      return id;
    }

    public async Task<int> DeleteAsync(Category category)
    {
      return await DeleteAsync(category.Id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
      return await _context.Categories.AsNoTracking().AnyAsync(x => x.Id == id);
    }


    }
}
