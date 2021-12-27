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
    public class AgeStatusController : Controller
    {
        [HttpGet]
        public IEnumerable<AgeStatus> Get()
        {
            return DataAccess.GetAgeStatuses();
        }

        [HttpGet("{AgeStatusID}")]
        public ActionResult<AgeStatus> Get(int ageStatusID)
        {
            var result = DataAccess.GetAgeStatus(ageStatusID);
            if (result == null)
                return NotFound();

            return result;
        }
    }
}
