using CropTracking.API.Models;
using System.Collections.Generic;

namespace CropTracking.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<SubmissionsDto> Submissions { get; set; }

        public CitiesDataStore()
        {
            // dummy data
            Submissions = new List<SubmissionsDto>
            {
                new SubmissionsDto
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park."
                },
                new SubmissionsDto
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished."
                },
                new SubmissionsDto
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower."
                }
            };
        }
    }
}
