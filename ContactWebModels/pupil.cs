using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
  public class Pupil
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("Lecture")]
    public int? LectureId { get; set; }
   // [InverseProperty("Pupils")]
    public virtual ICollection<Lecture>? Lectures { get; set; }
    public string UserId { get; set; }

    public Pupil()
    {
      var pupils = new List<Pupil>
      {
          new Pupil { Id = 1, Name = "John" },
          new Pupil { Id = 2, Name = "Jane" }
      };
    }
//   //end
  }
}
