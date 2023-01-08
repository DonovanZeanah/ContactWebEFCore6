using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactWebModels;
using MyContactManagerData;

namespace ContactWebEFCore6.Controllers
{
    public class SuppliesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    public IActionResult Random()
    {
      var supplyItem = new Supply() { Name = "Screws" };
      return View(supplyItem);
    }
  }
}
