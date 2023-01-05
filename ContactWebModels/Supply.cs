using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactWebModels
{
  public class Supply
  {
    [Key]
    public int ItemId { get; set; }

    [Display(Name = "Category")]
    [Required(ErrorMessage = "A category must be assigned")]
    [StringLength(ContactManagerConstants.MAX_CATEGORY_LENGTH)]
    public int CategoryId { get; set; }

    [Display(Name = "Item Name")]
    [Required(ErrorMessage = "A Name is required")]
    [StringLength(ContactManagerConstants.MAX_NAME_LENGTH)]
    public string ItemName { get; set; }

    public double Price { get; set; }
    public int Quantity { get; set; }

    public int ContactId { get; set; }

    public virtual List<Contact> Contact { get; set; }
        public int Id { get; set; }
    }
}