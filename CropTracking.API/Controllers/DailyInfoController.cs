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

        // TODO: Now: Write a new method called Create that is an HttpPost method...
        //  This method will receive a DailyInfoDto object and insert it into the database.
        //
        // TODO 1: Write a new method called Create that will implement the Post action, following along with the 
        //      Pluralsight video clip "Demo: Creating a Resource". (You will be doing everything he is doing in this clip 
        //      but with our project instead of his.)
        //      - Your route in the HttpPost attribute will not have anything in the parentheses, 
        //          so it will look like [HttpPost()]
        //      - The only parameter you will have on the Create method will be a DailyInfoDto and should have the [FromBody] attribute
        //      - Add check for null and return BadRequest like video.
        //      - We don't have a parent object to check for in our case, so skip the second check he does.
        //      - Calculate the Id as he does
        //      - Create a DailyInformation object and set the DailyInformationId to 1 greater than the existing max 
        //          calculated in previous step (he does this with the ++maxPointOfInterestId.)
        //      - Copy several of the properties over from DailyInfoDto to DailyInformation as he is doing.
        //          -- We aren't going to copy ALL of the properties right now (there are WAY TOO MANY to do by hand!) 
        //              We'll learn a better way to do it later.
        //          -- Stick with just:
        //              PackShipDate
        //              ReportDate
        //              Conventional44ozInventory
        //              Organic60ozShipped
        //              Organic60ozPrice
        //      - Add the new DailyInformation object to the datastore - something like:
        //          CropDatatStore.Current.DailyInformation.Add(<whatever you named your new object>);
        //      - Return a created status like he did (CreatedAtRoute). Make sure to name the route for the GetById method like
        //          he does for his GetPointOfInterest method and use it in the CreatedAtRoute method call.
        //      - Build and fix any errors.

        // TODO 2: Use Postman to create a Post request. Follow what the instructor does in the video to see how to create this
        //  type of request. Your URL will be more like: http://localhost:54022/DailyInfo . Make sure you change the type of request
        //  to POST - the default is GET.
        //  
        //  - For the request body, you will use something like:
        //      {
        //          "PackShipDate": "2017-08-29 00:00:00",
        //          "Organic60ozShipped": "1000",
        //          "Organic60ozPrice": "30.00"
        //      }
        //
        //  - Because of how I setup the DailyInfoDto class, the ReportDate will automatically get filled in when it is passed into the method. 
        //      That's why I am still having you copy it from the DailyInfoDto to the DailyInformation class even though it's not provided
        //      in the request body sample above.
        //
        //  - Don't forget in Postman, when you create the Body, to set the type to "raw" and the drop-down to "JSON (application-json)".
        //      That will set the Content-Type in the Headers "tab".
        //
        //  - Run your request and see if you get the Created response like he did and see if you get an object back that has the data
        //      you used to fill in the appropriate properties. You will see ALL of the properties in the object, so scroll to find
        //      the ones you set in the create.
        //  - Also check the Headers to see if you got the Location back. Copy this Location header URL.
        //  - Create a new request in Postman (you have have multiple open at a time in tabs) and paste the URL into it. Make sure it is
        //      set to GET and Send it.
        //      -- Verify that you got the same data back that you did in the POST.





        // TODO: Later: Write a new method called Update that is an HttpPut method...
        //  This method will receive a DailyInfoDto object and update it in the database.
    }
}
