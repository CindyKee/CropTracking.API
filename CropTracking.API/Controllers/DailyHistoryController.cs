namespace CropTracking.API.Controllers
{ 

using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CropTracking.API.Helpers;


    [Route("api/[controller]")]
    public class DailyHistoryController : Controller
    {

        [HttpGet()]
        public IActionResult GetHistory()
        {
            return Ok(CropDataStore.Current.DailyHistory);
        }


        [HttpGet("{packShipDate:datetime?}")]
        public IActionResult GetDailyHistory(DateTime? packShipDate, [FromQuery]string companyName)
        {
            if (packShipDate.HasValue == false)
            {

                packShipDate = Helpers.DateHelpers.GetYesterday(DateTime.Today);
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                return NotFound();
            }

            var dailyHistory = CropDataStore.Current.DailyHistory
                .FirstOrDefault(d => d.CompanyName == companyName && d.PackShipDate == packShipDate);


            if (dailyHistory == null)
            {
                return NotFound();
            }

            return Ok(dailyHistory);
        }


    };




    
}
