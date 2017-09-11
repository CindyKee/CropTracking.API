using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CropTracking.API.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using CropTracking.API.Models;
using Microsoft.Extensions.Logging;
using CropTracking.API.Services;

namespace CropTracking.API.Controllers
{
    [Route("api/[controller]")]
    public class DailyInfoController : Controller
    {
        private ILogger<DailyInfoController> _logger;
        private IMailService _mailService;


        public DailyInfoController(ILogger<DailyInfoController> logger,
            IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        [HttpGet()]
        public IActionResult GetDailyInfo(int infoId)
        {

            try
            {
                throw new Exception("Exception sample");


                var info = CropDataStore.Current.DailyInformation.FirstOrDefault(p => p.DailyInformationId == infoId);

                if (info == null)
                {
                    _logger.LogInformation($"Info with id {infoId} wasn't found.");
                    return NotFound();
                }

                return Ok(CropDataStore.Current.DailyInformation);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting info with id {infoId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        

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

        [HttpGet("{id:int}", Name = "GetByIds")]
        public IActionResult GetById(int infoId)
        {

            try
            {
                throw new Exception("Exception sample");


                var info = CropDataStore.Current.DailyInformation.FirstOrDefault(p => p.DailyInformationId == infoId);

                if (info == null)
                {
                    _logger.LogInformation($"Info with id {infoId} wasn't found.");
                    return NotFound();
                }

                return Ok(CropDataStore.Current.DailyInformation);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting info with id {infoId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }


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

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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


            CropDataStore.Current.Save();
            // TODO 2 - Call Save here to rewrite the file with all of the current data.
            //      Save is a method on the Current property of the CropDataStore. See if 
            //      you can figure out how to call that. It does not return anything.

            return CreatedAtRoute("GetById", new { id = dinfo.DailyInformationId }, dinfo);

        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Models.DailyInfoDto dailyInfo)
        {
            if (dailyInfo == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var record = CropDataStore.Current.DailyInformation.SingleOrDefault(whatever => whatever.DailyInformationId == id);

            if (record == null)
            {
                return NotFound();
            }

            record.PackShipDate = dailyInfo.PackShipDate;
            record.DailyInformationId = dailyInfo.DailyInformationId;
            record.ReportDate = dailyInfo.ReportDate;
            record.Conventional44ozInventory = dailyInfo.Conventional44ozInventory;
            record.Organic60ozShipped = dailyInfo.Organic60ozShipped;
            record.Organic60ozPrice = dailyInfo.Organic60ozPrice;
            
            CropDataStore.Current.Save();

            return NoContent();
        }
        
        [HttpPatch("{id:int}")]

        public IActionResult PartialUpdate(int id,
            [FromBody] JsonPatchDocument<DailyInfoDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var idiots = CropDataStore.Current.DailyInformation.SingleOrDefault(whatever => whatever.DailyInformationId == id);
            if (idiots == null)
            {
                return NotFound();
            }

            var dailyInfoToPatch =
                    new DailyInfoDto()
                    {
                        PackShipDate = idiots.PackShipDate,
                        DailyInformationId = idiots.DailyInformationId,
                        ReportDate = idiots.ReportDate,
                        Conventional44ozInventory = idiots.Conventional44ozInventory,
                        Organic60ozShipped = idiots.Organic60ozShipped,
                        Organic60ozPrice = idiots.Organic60ozPrice
                    };
            patchDoc.ApplyTo(dailyInfoToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            idiots.PackShipDate = dailyInfoToPatch.PackShipDate;
            idiots.DailyInformationId = dailyInfoToPatch.DailyInformationId;
            idiots.ReportDate = dailyInfoToPatch.ReportDate;
            idiots.Conventional44ozInventory = dailyInfoToPatch.Conventional44ozInventory;
            idiots.Organic60ozShipped = dailyInfoToPatch.Organic60ozShipped;
            idiots.Organic60ozPrice = dailyInfoToPatch.Organic60ozPrice;


            CropDataStore.Current.Save();

            return NoContent();

        }

       [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var record = CropDataStore.Current.DailyInformation.FirstOrDefault(whatever => whatever.DailyInformationId == id);

            if (record == null)
            {
                return NotFound();
            }

            _mailService.Send("Daily Info deleted.",
                    $"Daily Info with id {record.DailyInformationId} was deleted.");

            CropDataStore.Current.DailyInformation.Remove(record);

            CropDataStore.Current.Save();

            return NoContent();


        }

        // TODO 5: Begin watching the next clip, "Demo: Partially Updating a Resource.
        //  - Try to write a PartialUpdate method like he is doing in this clip. 
        //  - The Route string in the HttpPut will be the same as route for GetById, 
        //      but without the Name property.
        //  - Use the DailyInfoPto in place of the "ForUpdate" Dto he uses in the video.
        //      We don't use separate DTOs for Create and Update like he does. In a larger system,
        //      that might make sense, but this is really a small application.
        //  - See how far you can get with this. Don't forget to Save it! I have never written 
        //      a Partial Update (PATCH) method before, so if you get this to work, you're awesome! :)

        // TODO 6: Using Postman, try several different kinds of updates like he does in his video.
        //          Add a check for ModelState validation like he does (if you get this far.)

        // TODO 7: Regardless if you were successful with a PATCH Partial Update, finish watching 
        //  the video clip.

        // TODO 8: Write a new method called Delete that is an HttpDelete method. Follow along
        //  with Pluralsight clip "Demo: Deleting a Resource" and see how far you can get in 
        //  writing this Update method. 
        //      - You will be receiving an Id for an object that already exists 
        //          in the CropDataStore and then deleting it. 
        //          -- Don't forget to Save it, but realize when you do, it will truly be deleted. :)
        //      - The Route string in the HttpDelete will be the same as route for GetById, 
        //          but without the Name property.

        // TODO 9: Using Postman, test the new Delete (DELETE) method. Try 2 kinds of tests:
        //      1 - A successful test, meaning that the Id sent must be one that exists
        //          in our Json file.
        //      2 - A Not Found test, where you send a DELETE request with an Id that doesn't
        //          exist in the file yet.


    }
}
