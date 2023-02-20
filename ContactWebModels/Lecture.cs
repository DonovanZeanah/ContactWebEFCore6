using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
  public class Lecture
  {
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    //public List<Enrollment> Enrollments { get; set; }
    [ForeignKey("Pupil")]
    public int? pupilId { get; set; }
   // [InverseProperty("Lectures")]
    public virtual ICollection<Pupil>? Pupils { get; set; }
    public string UserId { get; set; }
    public Lecture()
    {
      var courses = new List<Lecture>
{
    new Lecture { Id = 1, Title = "Math" },
    new Lecture { Id = 2, Title = "Science" }
};
    }
  }
}
