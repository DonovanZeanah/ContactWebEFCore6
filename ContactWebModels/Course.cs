using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
  public class Course
  {
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Student> Students { get; set; }
  }
}
