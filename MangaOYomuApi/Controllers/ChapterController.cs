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
    public class ChapterController : Controller
    {
        [HttpGet]
        public IEnumerable<Chapters> Get()
        {
            return DataAccess.GetChapters();
        }

        [HttpGet("{ChaptersID}")]
        public ActionResult<Chapters> Get(int chaptersID)
        {
            var result = DataAccess.GetChapter(chaptersID);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(Chapters chapter)
        {
            DataAccess.AddNewChapter(chapter);
            return NoContent();
        }
    }
}
