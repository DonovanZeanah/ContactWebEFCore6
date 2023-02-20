using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
  public class Enrollment
  {
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(Id))]
    public int PupilId { get; set; }
    public Pupil Pupil { get; set; }
    [ForeignKey(nameof(Id))]

    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }
    public string UserId { get; set; }

    public Enrollment()
    {
      var enrollments = new List<Enrollment>
{
    new Enrollment { PupilId = 1, LectureId = 1 },
    new Enrollment { PupilId = 2, LectureId = 1 },
    new Enrollment { PupilId = 2, LectureId = 2 }
};
    }
  }
}
