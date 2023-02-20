using ContactWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using MyContactManagerServices;
using MyContactManagerServices.interfaces;

namespace ContactWebEFCore6.Controllers
{
  public class PupilController : Controller
  {
    private readonly PupilsService _pupilsService;
    //private readonly IStudentsService _statesService;
    private readonly List<Enrollment> _allEnrollments;
    //private IMemoryCache _cache;
    public PupilController(PupilsService pupilsService, EnrollmentsService EnrollmentService, List<Enrollment> allEnrollments)
    {
      _pupilsService = pupilsService;
      _allEnrollments = allEnrollments;
    }
    public ActionResult Index()
    {
      var pupils = _pupilsService;
      return View(pupils);
    }
  }
}
