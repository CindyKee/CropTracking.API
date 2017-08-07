using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropTracking.API.Helpers
{
    public class DateHelpers
    {
        public static DateTime GetYesterday(DateTime packShipDate)
        {
            //  Get 
            DateTime yesterday;
            switch (packShipDate.DayOfWeek)
            {
                // The only day we adjust "Yesterday" for is when today is Monday.
                //case DayOfWeek.Sunday:
                //    yesterday = packShipDate.AddDays(-2);
                //    break;
                case DayOfWeek.Monday:
                    yesterday = packShipDate.AddDays(-3);
                    break;
                default:
                    yesterday = packShipDate.AddDays(-1);
                    break;
            };

            return yesterday;
        }

        public static string ValidatePackShipDate(DateTime packShipDate)
        {
            //  Don't allow user to select a date in the future
            if (packShipDate.Date > DateTime.Today.Date)
                return "Dates that are in the future are not permitted.";

            //  Don't allow user to select a date from a previous year
            if (packShipDate.Year < DateTime.Today.Year)
                return "Only information for the current year is permitted.";

            //  Date validates - no message returned
            return String.Empty;
        }

    }
}
