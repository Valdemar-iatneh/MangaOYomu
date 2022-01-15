using MangaOYomu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//удалить ненужные using 

namespace MangaOYomuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaTitleController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<MangaTitle> Get()
        {
            return DataAccess.GetMangaTitles();
        }

        [HttpGet("{MangaTitleID}")]
        public ActionResult<MangaTitle> Get(int MangaTitleID)
        {
            var result = DataAccess.GetMangaTitle(MangaTitleID);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(MangaTitle mangaTitle)
        {
            DataAccess.AddNewMangaTitle(mangaTitle);
            return NoContent();
        }

        [HttpDelete("{MangaTitleID}")]
        public IActionResult Delete(int mangaTitleID)
        {
            var result = DataAccess.GetMangaTitle(mangaTitleID);
            if (result == null)
                return NotFound();

            DataAccess.DeleteMangaTitle(mangaTitleID);
            return NoContent();
        }
    }
}
