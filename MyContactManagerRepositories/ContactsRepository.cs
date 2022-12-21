using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using MyContactManagerData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactManagerRepositories
{
  public class ContactsRepository : IContactsRepository
  {
    private readonly MyContactManagerDbContext _context;

    public ContactsRepository(MyContactManagerDbContext context)
    {
      _context = context;
    }

    public async Task<List<Contact>> GetAllAsync()
    {
      var allContactsData = await _context.Contacts.AsNoTracking().OrderBy(x => x.LastName).ToListAsync();
      return allContactsData;
    }

    public async Task<Contact> GetAsync(int id)
    {
      var contact = await _context.Contacts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
      return contact;
    }
    public async Task<int> AddOrUpdateAsync(Contact contact)
    {
      if (contact.Id == 0)
      {
        return await Insert(contact);
      }
      return await Update(contact);
    }

    private async Task<int> Insert(Contact contact)
    {
      await _context.Contacts.AddAsync(contact);
      await _context.SaveChangesAsync();
      return contact.Id;
    }




    private async Task<int> Update(Contact contact)
    {
      var existingContact = await _context.Contacts.SingleOrDefaultAsync(x => x.Id == contact.Id);

      if (existingContact == null)
      {
        throw new Exception("contact not found homeboia");
      }
      existingContact.Birthday = contact.Birthday;
      existingContact.City = contact.City;
      existingContact.Email = contact.Email;
      existingContact.FirstName = contact.FirstName;
      existingContact.LastName = contact.LastName;
      existingContact.PhonePrimary = contact.PhonePrimary;
      existingContact.PhoneSecondary = contact.PhoneSecondary;
      existingContact.Zip = contact.Zip;
      existingContact.StreetAddress1 = contact.StreetAddress1;
      existingContact.StreetAddress2 = contact.StreetAddress2;




      return existingContact.Id;

    }

    public async Task<bool> ExistsAsync(int id)
    {
      return await _context.Contacts.AsNoTracking().AnyAsync(x => x.Id == id);

    }


    public async Task<int> DeleteAsync(int id)
    {
      var contactToDelete = await GetAsync(id);
      try
      {
        _context.Remove(contactToDelete);
        _context.SaveChanges();
        return id;
      }
      catch
      {
        return 0;
      }
    }



    public async Task<int> DeleteAsync(Contact contact)
    {
      return await DeleteAsync(contact.Id);
    }

    Task<List<State>> IContactsRepository.GetAllAsync()
    {
      throw new NotImplementedException();
    }

    Task<State> IContactsRepository.GetAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}
