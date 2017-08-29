using Microsoft.AspNetCore.Mvc;
using System;
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
            // TODO 4: Time to go back and start watching Module 4 of the Pluralsight course. Need to see how 
            //  to do creates and updates through the Web API.
        }
    }
}
