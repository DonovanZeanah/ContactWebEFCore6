using Microsoft.AspNetCore.Mvc;

namespace ContactWebEFCore6.Controllers
{
  public class LectureController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
