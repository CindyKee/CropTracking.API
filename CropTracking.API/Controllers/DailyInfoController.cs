using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CropTracking.API.Helpers;


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
        public IActionResult Get(DateTime? packShipDate, [FromQuery]string companyName)
        {
            if (packShipDate.HasValue == false)
            {

                packShipDate = Helpers.DateHelpers.GetYesterday(DateTime.Today);
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

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var record = CropDataStore.Current.DailyInformation.SingleOrDefault(whatever => whatever.DailyInformationId == id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);

        }

        // TODO 1: Start watching video clip "Demo: Validating Input".
        //  - At around timecode 2:29, when he adds a Required attribute to a property, you add
        //      a [Required] attribute to the PackShipDate property of the DailyInfoDto class.
        //      (Ignore all of the Display attributes already on the many properties.)
        //  - At timecode 3:30 - 4:15, he starts adding the ModelState validation check to his code.
        //      You add the same check to your code and return the same BadRequest.
        //      Test using Postman and NOT including a PackShipDate in your body of data.
        //  - At timecode 4:50, add an error message to your Required attribute like he does. Use
        //      an error message that make sense for the PackShipDate.
        //  - At timecode 5:00, add ModelState to the returned BadRequest like he does.
        //      Test using Postman without a PackShipDate in your request.
        //  - Finish watching this video clip.

        [HttpPost()]
        public IActionResult Create([FromBody] Models.DailyInfoDto dailyInfo)
        {
            if (dailyInfo == null)
            {
                return BadRequest();
            }


            var maxDailyInfoId = CropDataStore.Current.DailyInformation.Max(p => p.DailyInformationId);

            var dinfo = new Models.DailyInformation()
            {
                DailyInformationId = ++maxDailyInfoId,
                PackShipDate = dailyInfo.PackShipDate,
                ReportDate = dailyInfo.ReportDate,
                Conventional44ozInventory = dailyInfo.Conventional44ozInventory,
                Organic60ozShipped = dailyInfo.Organic60ozShipped,
                Organic60ozPrice = dailyInfo.Organic60ozPrice
                
            };

            CropDataStore.Current.DailyInformation.Add(dinfo);

            // TODO 2 - Call Save here to rewrite the file with all of the current data.
            //      Save is a method on the Current property of the CropDataStore. See if 
            //      you can figure out how to call that. It does not return anything.

            return CreatedAtRoute("GetById", new { id = dinfo.DailyInformationId }, dinfo);

        }


        // TODO 3: Write a new method called Update that is an HttpPut method. Follow along
        //  with Pluralsight clip "Demo: Updating a Resource" and see how far you can get in 
        //  writing this Update method. 
        //      - You will be receiving a DailyInfoDto and Id for an object that already exists 
        //          in the CropDataStore and then updating field(s) in it. 
        //      - The Route string in the HttpPut will be the same as route for GetById, 
        //          but without the Name property.
        
        // TODO 4: Using Postman, test the new Update (PUT) method. Try 2 kinds of tests:
        //      1 - A successful test, meaning that the Id sent must be one that exists
        //          in our Json file.
        //      2 - A Not Found test, where you send a PUT request with an Id that doesn't
        //          exist in the file yet.
        
    }
}
