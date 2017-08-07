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
            return Ok(CropDataStore.Current.DailyInformation);
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
            if (packShipDate.HasValue == false)
            {
                // TODO 1: Remove the CropTracking.API. that is gray here and add a using statement at the top.
                packShipDate = CropTracking.API.Helpers.DateHelpers.GetYesterday(DateTime.Today);
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                return NotFound();
            }

            // Get data for requested date for this Company (if company provided)
            // TODO: After EF is added: use AutoMapper to convert this to a DTO.
            var dailyInfo = CropDataStore.Current.DailyInformation
                .FirstOrDefault(d => d.CompanyName == companyName && d.PackShipDate == packShipDate);

            // TODO: After EF is added: Set Processed flag
            //dailyInfo.Processed = VerifyDataNotAlreadyProcessed(companyName, packShipDate);

            if (dailyInfo == null)
            {
                return NotFound();
            }

            return Ok(dailyInfo);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var record = CropDataStore.Current.DailyInformation.SingleOrDefault(whatever => whatever.DailyInformationId == id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);

        }

        // TODO: Later: Write a new method called Update that is an HttpPut method...
        //  This method will receive a DailyInfoDto object and update it in the database.
    }
}
