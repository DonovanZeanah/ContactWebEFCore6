using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactWebModels
{
  public class Supply
  {

    List<Contact> contacts;

    [Key]
    public int Id { get; set; }
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public int SourceId { get; set; }

    

   // public int? CategoryId { get; set; }
   // public Category Category { get; set; }

    //[Display(Name = "Category")]
    //[Required(ErrorMessage = "A category must be assigned")]
    
    public virtual Category? Category { get; set; }
    public ICollection<Category> Categories { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    [Display(Name = "Contact")]
    public int? ContactId { get; set; }

    // public virtual ICollection<Contact>? Contacts { get; set; } 

    public virtual List<Contact>? Contact { get; set; }
    public virtual ICollection<Source>? Sources { get; set; }
    //public int? SourceId { get; set; }
    [Required(ErrorMessage = "The User ID is required in order to map the contact to a user correctly")]
    public string UserId { get; set; }
  }
}