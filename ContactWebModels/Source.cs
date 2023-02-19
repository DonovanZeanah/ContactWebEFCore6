using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
  public class Source
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    public int SupplyId { get; set; }
<<<<<<< HEAD
    public int? ContactId { get; set; }
=======
    public int ContactId { get; set; }
>>>>>>> db6920b0d61169aae8f67a44d1895117ba30a8f7
    public virtual Supply? Supply { get; set; }
    public virtual Contact? Contact { get; set; }

  }
}
