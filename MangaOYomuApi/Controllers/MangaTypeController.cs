using MangaOYomu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaOYomuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaTypeController : Controller
    {
        [HttpGet]
        public IEnumerable<MangaType> Get()
        {
            return DataAccess.GetMangaTypes();
        }

        [HttpGet("{MangaTypeID}")]
        public ActionResult<MangaType> Get(int mangaTypeID)
        {
            var result = DataAccess.GetMangaType(mangaTypeID);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
