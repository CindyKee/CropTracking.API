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

        public List<DailyInformation> DailyHistory { get; set; }

        public List<DailyInformation> DailyInformationFeeds { get; set; }


        public CropDataStore()
        {
            // sample data
            // read from json file
            using (var r = File.OpenText("DailyInformation.json"))
            {
                var json = r.ReadToEnd();
                DailyInformation = JsonConvert.DeserializeObject<List<DailyInformation>>(json);

                DailyHistory = JsonConvert.DeserializeObject<List<DailyInformation>>(json);

                DailyInformationFeeds = JsonConvert.DeserializeObject<List<DailyInformation>>(json);
            }
        }

        /// <summary>
        /// Rewrite the JSON file back out with any changes that we have made so far.
        /// </summary>
        public void Save()
        {
            var json = JsonConvert.SerializeObject(DailyInformation, Formatting.Indented);

            // write string to file
            File.WriteAllText("DailyInformation.json", json);
        }
    }
}
