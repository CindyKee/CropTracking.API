using CropTracking.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CropTracking.API
{
    public class CropDataStore
    {
        public static CropDataStore Current { get; } = new CropDataStore();

        public List<DailyInformation> DailyInformation { get; set; }

        // TODO 2: Duplicate the DailyInformation property above and call it DailyHistory

        public CropDataStore()
        {
            // sample data
            // read from json file
            using (var r = File.OpenText("DailyInformation.json"))
            {
                var json = r.ReadToEnd();
                DailyInformation = JsonConvert.DeserializeObject<List<DailyInformation>>(json);
                // TODO 3: Duplicate the previous line and assign the results to the DailyHistory property instead.
            }
        }
    }
}
