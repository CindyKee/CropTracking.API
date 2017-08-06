using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
 
namespace CropTracking.API.Controllers
{
    [Route("api/[controller]")]
    public class DailyInfoController : Controller
    {
        [HttpGet()]
        public IActionResult GetDailyInfo()
        {
            return Ok(CropDataStore.Current.Submissions);
        }

        /// <summary>
        /// Ported from Submissions Controller.Index
        /// </summary>
        /// <param name="packShipDate"></param>
        /// <param name="companyName"></param>
        /// <returns></returns>
        [HttpGet("{packShipDate:datetime?}")]
        public IActionResult GetDailyInfo(DateTime? packShipDate, [FromQuery]string companyName)
        {
            // TODO: If packShipDate not provided, set it to Yesterday using DateHelpers class

            // TODO: Check to see if company exists

            // Get data for requested date for this Company (if company provided)
            // TODO: After EF is added, include company in query below
            var dailyInfo = CropDataStore.Current.Submissions
                .FirstOrDefault(d => d.PackShipDate == packShipDate);

            // TODO: After EF is added, Set Processed flag

            if (dailyInfo == null)
            {
                return NotFound();
            }

            return Ok(dailyInfo);
        }
    }
}
