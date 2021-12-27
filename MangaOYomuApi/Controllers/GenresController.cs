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
    public class GenresController : Controller
    {
        [HttpGet]
        public IEnumerable<Genres> Get()
        {
            return DataAccess.GetGenres();
        }

        [HttpGet("{GenresID}")]
        public ActionResult<Genres> Get(int genresID)
        {
            var result = DataAccess.GetGenre(genresID);
            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(Genres genre)
        {
            DataAccess.AddNewGenre(genre);
            return NoContent();
        }

        [HttpPut("{GenresID}")]
        public IActionResult Update(int genresID, Genres genre)
        {
            var result = DataAccess.GetGenre(genresID);
            if (result == null)
                return NotFound();

            DataAccess.UpdateGenres(genresID, genre);

            return NoContent();
        }

        [HttpDelete("{GenresID}")]
        public IActionResult Delete(int genresID)
        {
            var result = DataAccess.GetGenre(genresID);
            if (result == null)
                return NotFound();

            DataAccess.DeleteGenre(genresID);
            return NoContent();
        }
    }
}
