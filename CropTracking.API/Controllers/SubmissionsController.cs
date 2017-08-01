using Microsoft.AspNetCore.Mvc;
using System.Linq;
 
namespace CropTracking.API.Controllers
{
    [Route("api/[controller]")]
    public class SubmissionsController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Submissions);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = CitiesDataStore.Current.Submissions.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
