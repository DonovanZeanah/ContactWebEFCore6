using ContactWebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerServices
{
    public interface ISupplysService
    {
    Task<List<Supply>> GetAllAsync(string itemId);
    Task<Supply> GetAsync(int id, string itemId);
    Task<int> Add(Supply itemId, string categoryId, int quantity);
    Task<int> Subtract(Supply itemId, string categoryId, int quantity);
    Task<bool> IsStockLow(int id, string itemId);



  }
}