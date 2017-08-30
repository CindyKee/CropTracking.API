using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CropTracking.API.Controllers
{

    [Route("api/[controller]")]

    public class DailyInfoFeedsController : Controller
    {
        [HttpGet()]
        public IActionResult GetDailyInformationFeeds()
        {
            return Ok(CropDataStore.Current.DailyInformationFeeds
                .OrderBy(sorted => sorted.CompanyName)
                .ThenBy(sorted => sorted.ReportDate));
        }
    }
}
