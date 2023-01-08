using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactWebModels;
using MyContactManagerData;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;
using ContactWebEFCore6.Models;
using MyContactManagerServices;
using Microsoft.AspNetCore.Authorization;

namespace ContactWebEFCore6.Controllers
{
  [Authorize(Roles = "Admin, SuperAdmin")]

  public class CategoriesController : Controller
    {
    private readonly IMemoryCache _cache;
    private ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService, IMemoryCache cache)
    {
      _categoriesService = categoriesService;
      _cache = cache;
    }

    public IActionResult Index()
        {
            return View();
        }
    }
}
