using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerServices
{
    public interface ISupplysRepository
    {
    Task<List<Supply>> GetAllAsync(string itemId);
    Task<Supply> GetAsync(int id, string itemId);
    Task<int> AddAsync(Supply s, string categoryId, int quantity);
    Task<int> DeleteAsync(int id, string itemId);

    Task<int> SubtractAsync(Supply s, string categoryId, int quantity);
    Task<bool> IsStockLow(int id, int quantity);



  }
}