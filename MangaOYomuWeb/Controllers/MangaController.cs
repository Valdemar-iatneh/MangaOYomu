using MangaOYomu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaOYomuWeb.Controllers
{
    public class MangaController : Controller
    {
        //public async Task<IActionResult> Index(int id)
        //{
        //    return View(await DataAccess.GetMangaTitle(id);
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
