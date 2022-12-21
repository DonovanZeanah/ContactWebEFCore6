using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyContactManagerData;
using MyContactManagerRepositories;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace MyContactManagerIntegrationTests
{
  public class TestContactsData
  {
    DbContextOptions<MyContactManagerDbContext> _options;
    private IContactsRepository _repository;

    private const int NUMBER_OF_CONTACTS = 5;
    private const string USERID1 = "477f8f3a-c343-40b5-b34a-7b8977e1a65d";
    private const string USERID2 = "f4a2d35d-4a49-4a12-8445-752857124620";
    private const string USERID3 = "6d597b0e-b259-4127-b7e2-02537a754c75";
    private const string FIRST_NAME_1 = "John";
    private const string LAST_NAME_1 = "Smith";
    private const string EMAIL_1 = "john.smith@example.com";
    private const string FIRST_NAME_2 = "Jane";
    private const string LAST_NAME_2 = "Smith";
    private const string EMAIL_2 = "jane.smith@example.com";
    private const string FIRST_NAME_3 = "Tim";
    private const string LAST_NAME_3 = "Thomas";
    private const string EMAIL_3 = "tim.thomas@example.com";
    private const string FIRST_NAME_4 = "Amanda";
    private const string LAST_NAME_4 = "Thomas";
    private const string EMAIL_4 = "amanda.thomas@example.com";
    private const string FIRST_NAME_5 = "James";
    private const string LAST_NAME_5 = "Davis";
    private const string EMAIL_5 = "james.davis@example.com";
    private const string FIRST_NAME_2_UPDATED = "Janet";


    public TestContactsData()
    {
      SetupOptions();
      BuildDefaults();
    }

    private void SetupOptions()
    {
      _options = new DbContextOptionsBuilder<MyContactManagerDbContext>()
                      .UseInMemoryDatabase(databaseName: "MyContactManagerContactsTests")
                      .Options;
    }

    public void BuildDefaults()
    {
      using (var context = new MyContactManagerDbContext(_options))
      {
        var existingStates = Task.Run(async () => await context.States.ToListAsync()).Result;

        if (existingStates is null || existingStates.Count < 5)
        {
          var states = GetStatesTestData();
          context.States.AddRange(states);
          context.SaveChanges();
        }

        var existingContacts = Task.Run(async () => await context.Contacts.ToListAsync()).Result;

        if (existingContacts is null || existingContacts.Count < 5)
        {
          var contacts = GetContactsTestData();
          context.Contacts.AddRange(contacts);
          context.SaveChanges();
        }
      }
    }

    private List<State> GetStatesTestData()
    {
      return new List<State>() {
                new State() { Id = 1, Name = "Alabama", Abbreviation = "AL" },
                new State() { Id = 2, Name = "Alaska", Abbreviation = "AK" },
                new State() { Id = 3, Name = "Arizona", Abbreviation = "AZ" },
                new State() { Id = 4, Name = "Arkansas", Abbreviation = "AR" },
                new State() { Id = 5, Name = "California", Abbreviation = "CA" }
            };
    }

    private List<Contact> GetContactsTestData()
    {
      return new List<Contact>() {
                new Contact() { Id = 1, Birthday = new DateTime(1947, 1, 1), City = "Los Angeles", Email=EMAIL_1, FirstName = FIRST_NAME_1
                                , LastName = LAST_NAME_1, PhonePrimary = "555-555-1111", PhoneSecondary = "555-555-1111", StateId= 5
                                , StreetAddress1 = "111 First St", StreetAddress2 = "Lot 11", UserId = USERID1, Zip="11111" },
                new Contact() { Id = 2, Birthday = new DateTime(1972, 11, 3), City = "Little Rock", Email=EMAIL_2, FirstName = FIRST_NAME_2
                                , LastName = LAST_NAME_2, PhonePrimary = "555-555-2222", PhoneSecondary = "555-555-2222", StateId= 4
                                , StreetAddress1 = "222 Second St", StreetAddress2 = "Apt 22", UserId = USERID1, Zip="22222" },
                new Contact() { Id = 3, Birthday = new DateTime(2001, 2, 4), City = "Phoenix", Email=EMAIL_3, FirstName = FIRST_NAME_3
                                , LastName = LAST_NAME_3, PhonePrimary = "555-555-3333", PhoneSecondary = "555-555-3333", StateId= 3
                                , StreetAddress1 = "333 Third St", StreetAddress2 = "STE 33", UserId = USERID2, Zip="33333" },
                new Contact() { Id = 4, Birthday = new DateTime(1982, 7, 23), City = "Fairbanks", Email=EMAIL_4, FirstName = FIRST_NAME_4
                                , LastName = LAST_NAME_4, PhonePrimary = "555-555-4444", PhoneSecondary = "555-555-4444", StateId= 2
                                , StreetAddress1 = "444 Fourth St", StreetAddress2 = "UNIT 44", UserId = USERID2, Zip="44444" },
                new Contact() { Id = 5, Birthday = new DateTime(1937, 8, 12), City = "Birmingham", Email=EMAIL_5, FirstName = FIRST_NAME_5
                                , LastName = LAST_NAME_5, PhonePrimary = "555-555-5555", PhoneSecondary = "555-555-5555", StateId= 1
                                , StreetAddress1 = "555 Fifth St", StreetAddress2 = "BOX 55", UserId = USERID3, Zip="55555" }
            };
    }

    [Fact]
    public async Task TestGetAll()
    {
      using (var context = new MyContactManagerDbContext(_options))
      {
        _repository = new ContactsRepository(context);

        var contacts = await _repository.GetAllAsync();
        contacts.Count.ShouldBe(NUMBER_OF_CONTACTS);

        contacts[2].FirstName.ShouldBe(FIRST_NAME_1, StringCompareShould.IgnoreCase);
        contacts[2].LastName.ShouldBe(LAST_NAME_1, StringCompareShould.IgnoreCase);
        contacts[2].UserId.ShouldBe(USERID1, StringCompareShould.IgnoreCase);
        contacts[2].Email.ShouldBe(EMAIL_1, StringCompareShould.IgnoreCase);

        contacts[1].FirstName.ShouldBe(FIRST_NAME_2, StringCompareShould.IgnoreCase);
        contacts[1].LastName.ShouldBe(LAST_NAME_2, StringCompareShould.IgnoreCase);
        contacts[1].UserId.ShouldBe(USERID1, StringCompareShould.IgnoreCase);
        contacts[1].Email.ShouldBe(EMAIL_2, StringCompareShould.IgnoreCase);

        contacts[4].FirstName.ShouldBe(FIRST_NAME_3, StringCompareShould.IgnoreCase);
        contacts[4].LastName.ShouldBe(LAST_NAME_3, StringCompareShould.IgnoreCase);
        contacts[4].UserId.ShouldBe(USERID2, StringCompareShould.IgnoreCase);
        contacts[4].Email.ShouldBe(EMAIL_3, StringCompareShould.IgnoreCase);

        contacts[3].FirstName.ShouldBe(FIRST_NAME_4, StringCompareShould.IgnoreCase);
        contacts[3].LastName.ShouldBe(LAST_NAME_4, StringCompareShould.IgnoreCase);
        contacts[3].UserId.ShouldBe(USERID2, StringCompareShould.IgnoreCase);
        contacts[3].Email.ShouldBe(EMAIL_4, StringCompareShould.IgnoreCase);

        contacts[0].FirstName.ShouldBe(FIRST_NAME_5, StringCompareShould.IgnoreCase);
        contacts[0].LastName.ShouldBe(LAST_NAME_5, StringCompareShould.IgnoreCase);
        contacts[0].UserId.ShouldBe(USERID3, StringCompareShould.IgnoreCase);
        contacts[0].Email.ShouldBe(EMAIL_5, StringCompareShould.IgnoreCase);

      }
    }
    [Theory]
    [InlineData(1, FIRST_NAME_1, LAST_NAME_1, USERID1, EMAIL_1)]
    [InlineData(2, FIRST_NAME_2, LAST_NAME_2, USERID1, EMAIL_2)]
    [InlineData(3, FIRST_NAME_3, LAST_NAME_3, USERID2, EMAIL_3)]
    [InlineData(4, FIRST_NAME_4, LAST_NAME_4, USERID2, EMAIL_4)]
    [InlineData(5, FIRST_NAME_5, LAST_NAME_5, USERID3, EMAIL_5)]

    public async Task TestGetOne(int contactId, string expectedFirstName,
                                 string expectedLastName, string expectedUserId, string expectedEmail)
    {
      using (var context = new MyContactManagerDbContext(_options))
      {
        _repository = new ContactsRepository(context);

        var contact = await _repository.GetAsync(contactId);
        contact.ShouldNotBe(null);
        contact.FirstName.ShouldBe(expectedFirstName);
        contact.LastName.ShouldBe(expectedLastName);
        contact.UserId.ShouldBe(expectedUserId);
        contact.Email.ShouldBe(expectedEmail);
      }
    }


    [Theory]
    [InlineData(0, "Walker", "Texas Ranger", "127498187491784", "Walker@texas.gov", "555-555-6666", "555-555-6666", 5, "66666", "Los Angeles", "666 Sixth St", "BOX 66")]
    public async Task AddAndDeleteContact(int contactId, string expectedFirstName, string expectedLastName,
                                          string expectedUserId, string expectedEmail, string expectedPhoneNumber,
                                          string expectedPhoneNumber2, int expectedStateId, string expectedZip,
                                          string expectedCity, string expectedStreetAddress1, string expectedStreetAddress2)
    {
      using (var context = new MyContactManagerDbContext(_options))
      {
        _repository = new ContactsRepository(context);

        //add the state and validate it is stored
        var contactToAdd = new Contact()
        {
          Id = contactId,
          FirstName = expectedFirstName,
          LastName = expectedLastName,
          UserId = expectedUserId,
          Email = expectedEmail,
          PhonePrimary = expectedPhoneNumber,
          PhoneSecondary = expectedPhoneNumber2,
          StateId = expectedStateId,
          Zip = expectedZip,
          City = expectedCity,
          StreetAddress1 = expectedStreetAddress1,
          StreetAddress2 = expectedStreetAddress2
        };
        await _repository.AddOrUpdateAsync(contactToAdd);

        var updatedContact = await _repository.GetAsync(contactToAdd.Id);
        updatedContact.ShouldNotBeNull();
        updatedContact.Id.ShouldBeGreaterThan(0);
        updatedContact.FirstName.ShouldBe(expectedFirstName, StringCompareShould.IgnoreCase);
        updatedContact.LastName.ShouldBe(expectedLastName, StringCompareShould.IgnoreCase);
        updatedContact.UserId.ShouldBe(expectedUserId, StringCompareShould.IgnoreCase);
        updatedContact.Email.ShouldBe(expectedEmail, StringCompareShould.IgnoreCase);
        updatedContact.PhonePrimary.ShouldBe(expectedPhoneNumber, StringCompareShould.IgnoreCase);
        updatedContact.StateId.ShouldBe(expectedStateId);
        updatedContact.Zip.ShouldBe(expectedZip, StringCompareShould.IgnoreCase);
        updatedContact.PhoneSecondary.ShouldBe(expectedPhoneNumber2, StringCompareShould.IgnoreCase);
        updatedContact.City.ShouldBe(expectedCity, StringCompareShould.IgnoreCase);
        updatedContact.StreetAddress1.ShouldBe(expectedStreetAddress1, StringCompareShould.IgnoreCase);
        updatedContact.StreetAddress2.ShouldBe(expectedStreetAddress2, StringCompareShould.IgnoreCase);

        //delete to keep current count and list in tact.
        await _repository.DeleteAsync(updatedContact.Id);
        var deletedState = await _repository.GetAsync(updatedContact.Id);
        deletedState.ShouldBeNull();
      }
    }

    [Fact]
    public async Task UpdateContact()
    {
      using (var context = new MyContactManagerDbContext(_options))
      {
        _repository = new ContactsRepository(context);

        var contactToUpdate = await _repository.GetAsync(1); //expected IWOA -> purposeful typo
        contactToUpdate.ShouldNotBeNull();
        contactToUpdate.FirstName.ShouldBe(FIRST_NAME_1, StringCompareShould.IgnoreCase);

        contactToUpdate.FirstName = FIRST_NAME_2_UPDATED;
        await _repository.AddOrUpdateAsync(contactToUpdate);

        var updatedContact = await _repository.GetAsync(1); //expected IWOA -> purposeful typo
        updatedContact.ShouldNotBeNull();
        updatedContact.FirstName.ShouldBe(FIRST_NAME_2_UPDATED, StringCompareShould.IgnoreCase);

        //put it back:
        updatedContact.FirstName = FIRST_NAME_1;
        await _repository.AddOrUpdateAsync(updatedContact);

        var revertedContact = await _repository.GetAsync(1); //expected IWOA -> purposeful typo
        revertedContact.ShouldNotBeNull();
        revertedContact.FirstName.ShouldBe(FIRST_NAME_1, StringCompareShould.IgnoreCase);
      }
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(3, true)]
    [InlineData(99, false)]
    public async Task TestExists(int id, bool expected)
    {
      using (var context = new MyContactManagerDbContext(_options))
      {
        _repository = new ContactsRepository(context);

        var exists = await _repository.ExistsAsync(id);
        exists.ShouldBe(expected);
      }
    }

  }
}