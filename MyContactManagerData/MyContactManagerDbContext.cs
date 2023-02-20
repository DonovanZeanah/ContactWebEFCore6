using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace MyContactManagerData
{
  public class MyContactManagerDbContext : DbContext
  {
    private static IConfigurationRoot _configuration;


    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<State> States { get; set; }
    public DbSet<Supply> Supplies { get; set; }
    public DbSet<Source> Sources { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<Lecture> lectures { get; set; }

    //

    public MyContactManagerDbContext()
    {
      //purposefully empty: Necessary for Scaffold 
    }

    public MyContactManagerDbContext(DbContextOptions options)
        : base(options)
    {
      //purposefully empty: sets options appropriatly
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {

        var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        
        _configuration = builder.Build();
        var cnstr = _configuration.GetConnectionString("ContactWebDbConnection");
        optionsBuilder.UseSqlServer(cnstr);
        optionsBuilder.EnableSensitiveDataLogging();
      }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<State>(x =>
      {
        x.HasData(
                  new State() { Id = 1, Name = "Alabama", Abbreviation = "AL" },
                  new State() { Id = 2, Name = "Alaska", Abbreviation = "AK" },
                  new State() { Id = 3, Name = "Arizona", Abbreviation = "AZ" },
                  new State() { Id = 4, Name = "Arkansas", Abbreviation = "AR" },
                  new State() { Id = 5, Name = "California", Abbreviation = "CA" },
                  new State() { Id = 6, Name = "Colorado", Abbreviation = "CO" },
                  new State() { Id = 7, Name = "Connecticut", Abbreviation = "CT" },
                  new State() { Id = 8, Name = "Delaware", Abbreviation = "DE" },
                  new State() { Id = 9, Name = "District of Columbia", Abbreviation = "DC" },
                  new State() { Id = 10, Name = "Florida", Abbreviation = "FL" },
                  new State() { Id = 11, Name = "Georgia", Abbreviation = "GA" },
                  new State() { Id = 12, Name = "Hawaii", Abbreviation = "HI" },
                  new State() { Id = 13, Name = "Idaho", Abbreviation = "ID" },
                  new State() { Id = 14, Name = "Illinois", Abbreviation = "IL" },
                  new State() { Id = 15, Name = "Indiana", Abbreviation = "IN" },
                  new State() { Id = 16, Name = "Iowa", Abbreviation = "IA" },
                  new State() { Id = 17, Name = "Kansas", Abbreviation = "KS" },
                  new State() { Id = 18, Name = "Kentucky", Abbreviation = "KY" },
                  new State() { Id = 19, Name = "Louisiana", Abbreviation = "LA" },
                  new State() { Id = 20, Name = "Maine", Abbreviation = "ME" },
                  new State() { Id = 21, Name = "Maryland", Abbreviation = "MD" },
                  new State() { Id = 22, Name = "Massachusetts", Abbreviation = "MS" },
                  new State() { Id = 23, Name = "Michigan", Abbreviation = "MI" },
                  new State() { Id = 24, Name = "Minnesota", Abbreviation = "MN" },
                  new State() { Id = 25, Name = "Mississippi", Abbreviation = "MS" },
                  new State() { Id = 26, Name = "Missouri", Abbreviation = "MO" },
                  new State() { Id = 27, Name = "Montana", Abbreviation = "MT" },
                  new State() { Id = 28, Name = "Nebraska", Abbreviation = "NE" },
                  new State() { Id = 29, Name = "Nevada", Abbreviation = "NV" },
                  new State() { Id = 30, Name = "New Hampshire", Abbreviation = "NH" },
                  new State() { Id = 31, Name = "New Jersey", Abbreviation = "NJ" },
                  new State() { Id = 32, Name = "New Mexico", Abbreviation = "NM" },
                  new State() { Id = 33, Name = "New York", Abbreviation = "NY" },
                  new State() { Id = 34, Name = "North Carolina", Abbreviation = "NC" },
                  new State() { Id = 35, Name = "North Dakota", Abbreviation = "ND" },
                  new State() { Id = 36, Name = "Ohio", Abbreviation = "OH" },
                  new State() { Id = 37, Name = "Oklahoma", Abbreviation = "OK" },
                  new State() { Id = 38, Name = "Oregon", Abbreviation = "OR" },
                  new State() { Id = 39, Name = "Pennsylvania", Abbreviation = "PA" },
                  new State() { Id = 40, Name = "Rhode Island", Abbreviation = "RI" },
                  new State() { Id = 41, Name = "South Carolina", Abbreviation = "SC" },
                  new State() { Id = 42, Name = "South Dakota", Abbreviation = "SD" },
                  new State() { Id = 43, Name = "Tennessee", Abbreviation = "TN" },
                  new State() { Id = 44, Name = "Texas", Abbreviation = "TX" },
                  new State() { Id = 45, Name = "Utah", Abbreviation = "UT" },
                  new State() { Id = 46, Name = "Vermont", Abbreviation = "VT" },
                  new State() { Id = 47, Name = "Virginia", Abbreviation = "VA" },
                  new State() { Id = 48, Name = "Washington", Abbreviation = "WA" },
                  new State() { Id = 49, Name = "West Virginia", Abbreviation = "WV" },
                  new State() { Id = 50, Name = "Wisconsin", Abbreviation = "WI" },
                  new State() { Id = 51, Name = "Wyoming", Abbreviation = "WY" }
              );
      });
      /*modelBuilder.Entity<Student>()
           .HasMany<Course>(s => s.Courses)
           .WithMany(c => c.Students)
           .Map(cs =>
           {
             cs.MapLeftKey("StudentRefId");
             cs.MapRightKey("CourseRefId");
             cs.ToTable("StudentCourses");
           });*/

      modelBuilder.Entity<Source>()
    .HasKey(so => new { so.SupplyId,so.ContactId, so.CategoryId });

      modelBuilder.Entity<Source>()
          .HasOne(so => so.Supply)
          .WithMany(s => s.Sources)
          .HasForeignKey(so => so.SupplyId);

      modelBuilder.Entity<Source>()
          .HasOne(so => so.Category)
          .WithMany(c => c.Sources)
          .HasForeignKey(so => so.CategoryId);

      modelBuilder.Entity<Supply>(x =>
      {
        x.HasData(
            new Supply() { Id = 1, UserId = "1", Name = "screws", SourceId = 1 },
            new Supply() { Id = 2, UserId = "1", Name = "rubber gloves", SourceId = 2 },
            new Supply() { Id = 3, UserId = "2", Name = "wooden plank", SourceId = 3 },
            new Supply() { Id = 4, UserId = "2", Name = "rust remover", SourceId = 4 },
            new Supply() { Id = 5, UserId = "3", Name = "ballpens", SourceId = 5 }
        );
      });

      modelBuilder.Entity<Category>(x =>
      {
        x.HasData(
            new Category() { Id = 1, Name = "Screws" },
            new Category() { Id = 2, Name = "Gloves" },
            new Category() { Id = 3, Name = "Wood" },
            new Category() { Id = 4, Name = "Chemicals" },
            new Category() { Id = 5, Name = "Office Supplies" }
        );

        x.HasMany(c => c.Supplies)
            .WithMany(s => s.Categories)
            .UsingEntity(j => j.HasData(
                new { CategoriesId = 1, SuppliesId = 1 },
                new { CategoriesId = 2, SuppliesId = 2 },
                new { CategoriesId = 3, SuppliesId = 3 },
                new { CategoriesId = 4, SuppliesId = 4 },
                new { CategoriesId = 5, SuppliesId = 5 }
            ));
      });
      /* modelBuilder.Entity<Category>(x =>
       {
         x.HasData(
                   new Category() { Id = 1, Name = "Hardware" },
                   new Category() { Id = 2, Name = "Consumables" },
                   new Category() { Id = 3, Name = "RawMaterials" },
                   new Category() { Id = 4, Name = "Hazmat" },
                   new Category() { Id = 5, Name = "OutSourced" }

               );
       });*/
      /*modelBuilder.Entity<Supply>(x =>
      {
        x.HasData(
                  new Supply() { Id = 1, UserId = "1" , CategoryId = 1, Name = "screws", SourceId = 1 },
                  new Supply() { Id = 2, UserId = "1", CategoryId = 2, Name = "rubber gloves", SourceId = 2 },
                  new Supply() { Id = 3, UserId = "2", CategoryId = 3, Name = "wooden plank", SourceId = 3 },
                  new Supply() { Id = 4, UserId = "2", CategoryId = 4, Name = "rust remover", SourceId = 4 },
                  new Supply() { Id = 5, UserId = "3", CategoryId = 5, Name = "ballpens", SourceId = 5 }

              );
      });*/
      modelBuilder.Entity<StudentCourse>().HasData(
         new StudentCourse { Id = 1, StudentId = 1, CourseId = 1, UserId = 2, },
         new StudentCourse { Id = 2, StudentId = 2, CourseId = 1, UserId = 1, },
         new StudentCourse { Id = 3, StudentId = 2, CourseId = 2, UserId = 1, }
     );
      modelBuilder.Entity<Student>().HasData(
           new Student { StudentId = 1, Name = "John", UserId = "1", },
           new Student { StudentId = 2, Name = "Jane", UserId = "1", }
       );

      modelBuilder.Entity<Course>().HasData(
          new Course { Id = 1, Title = "Math" },
          new Course { Id = 2, Title = "Science" }
      );
      modelBuilder.Entity<Contact>().HasData(
         new Contact
         {
           Id = 1,
           FirstName = "Annika",
           LastName = "Zeanah",
           StateId = 1,
           City = "Tuscaloosa",
           Zip = "35401",
           UserId = "2",
           Email = "something1@one.com",
           PhonePrimary = "205799555",
           PhoneSecondary = "5555555555",
           StreetAddress1 = "1132 findout street",
           StreetAddress2 = "not again blvd"
         },

         new Contact
         {
           Id = 2,
           FirstName = "Cheryl",
           LastName = "Zeanah",
           StateId = 1,
           City = "Tuscaloosa",
           Zip = "35401",
           UserId = "1",
           Email = "something2@one.com",
           PhonePrimary = "205799555",
           PhoneSecondary = "5555555555",
           StreetAddress1 = "1132 findout street",
           StreetAddress2 = "not again blvd"
         },

         new Contact
         {
           Id = 3,
           FirstName = "Kris",
           LastName = "Zeanah",
           StateId = 1,
           City = "Tuscaloosa",
           Zip = "35401",
           UserId = "1",
           Email = "something3@one.com",
           PhonePrimary = "205799555",
           PhoneSecondary = "5555555555",
           StreetAddress1 = "1132 findout street",
           StreetAddress2 = "not again blvd"
         }

     );
     /* modelBuilder.Entity<Source>().HasData(
         new Source { Id = 1, ContactId = 1, SupplyId = 1, UserId = "2", },
         new Source { Id = 2, ContactId = 2, SupplyId = 1, UserId = "1", },
         new Source { Id = 3, ContactId = 2, SupplyId = 2, UserId = "1", }
     );*/


    }

    public class StudentCourse
    {
      [Key]
      public int Id { get; set; }
      public int StudentId { get; set; }
      public Student Student { get; set; }
      public int CourseId { get; set; }
      public Course Course { get; set; }
      public int UserId { get; internal set; }
    }

  }

}
