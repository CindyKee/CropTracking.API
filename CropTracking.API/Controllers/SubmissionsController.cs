using Microsoft.AspNetCore.Mvc;
using System.Linq;
 
namespace CropTracking.API.Controllers
{
    [Route("api/[controller]")]
    public class SubmissionsController : Controller
    {
        [HttpGet()]
        public IActionResult GetDailyInfo()
        {
            return Ok(CropDataStore.Current.Submissions);
        }

        [HttpGet("{id}")]
        public IActionResult GetDailyInfo(int id)
        {
            var city = CropDataStore.Current.Submissions.FirstOrDefault(c => c.DailyInformationId == id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
