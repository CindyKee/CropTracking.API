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
            // TODO 1: Create new Solution Folder in Solution Explorer called 'Helpers'
            // TODO 2: Create new class in that folder called DateHelpers
            // TODO 3: Copy code from original DateHelpers class into this new one. 
            //  See https://cncconsulting.visualstudio.com/DataDesigners/DataDesigners%20Team/_versionControl?path=%24%2FDataDesigners%2FBMRIC%2FBMRIC2.0%2FBMRIC2.0%2FHelpers%2FDateHelpers.cs
            // TODO 4: If packShipDate is null, set it to Yesterday using DateHelpers class
            //  HINT: To check if a nullable DateTime is null, use packShipDate.HasValue
            //  See Line 93 in https://cncconsulting.visualstudio.com/DataDesigners/DataDesigners%20Team/_versionControl?path=%24%2FDataDesigners%2FBMRIC%2FBMRIC2.0%2FBMRIC2.0%2FControllers%2FSubmissionsController.cs
            //      for how to call the DateHelpers class method to get Yesterday.


            // TODO 5: Check to see if company exists in request; If not, return Not Found.
            //  HINT: Use string.IsNullOrWhitespace(companyName) to see if it has a value.



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

        // TODO 6: Write a new method called GetById that is another HttpGet method. 
        //  It will have one parameter - an integer called 'id'.
        //  You will use a statement similar to the FirstOrDefault statement in the previous method, except this
        //  time you will use SingleOrDefault and you will compare the DailyInformationId to the id parameter.
        //  Return Not Found if you don't get anything back. Otherwise, return Ok and include the data.

        // TODO: Later: Write a new method called Update that is an HttpPut method...
        //  This method will receive a DailyInfoDto object and update it in the database.
    }
}
