using CropTracking.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CropTracking.API
{
    public class CropDataStore
    {
        public static CropDataStore Current { get; } = new CropDataStore();

        public List<DailyInfoDto> Submissions { get; set; }

        public CropDataStore()
        {
            // sample data
            // read from json file
            using (var r = File.OpenText("DailyInformation.json"))
            {
                var json = r.ReadToEnd();
                Submissions = JsonConvert.DeserializeObject<List<DailyInfoDto>>(json);
            }
        }
    }
}
