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
    public class TitleStatusController : Controller
    {
        [HttpGet]
        public IEnumerable<TitleStatus> Get()
        {
            return DataAccess.GetTitleStatuses();
        }

        [HttpGet("{TitleStatusID}")]
        public ActionResult<TitleStatus> Get(int titleStatusID)
        {
            var result = DataAccess.GetTitleStatus(titleStatusID);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
