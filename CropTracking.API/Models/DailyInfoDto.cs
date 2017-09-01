using System;
using System.ComponentModel.DataAnnotations;


namespace CropTracking.API.Models
{
    public class DailyInfoDto
    {
        public DailyInfoDto()
        {
            //  Initialize our dates
            var today = DateTime.Today;
            PackShipDate = (today.DayOfWeek == DayOfWeek.Monday)
                ? today.AddDays(-3)
                : today.AddDays(-1);


        }

        public override string ToString()
        {
            return $"Pack/Ship Date: {PackShipDate.ToString("MM/dd/yyyy")}";
        }

        #region Public Properties

        public bool Processed { get; set; }

        public int DailyInformationId { get; set; }

        // Set when the No Activity button is clicked instead of the Send button.
        public bool NoActivity { get; set; }

        [Required(ErrorMessage ="Pack Ship Date Required!")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Pack/Ship Date:")]
        public DateTime PackShipDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Report Date:")]
        public DateTime ReportDate { get; set; } = DateTime.Now;

        // ReSharper disable InconsistentNaming
        [Display(Name = " ")]
        public int? Conventional44ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Conventional44ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Conventional44ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Conventional44ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Conventional60ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Conventional60ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Conventional60ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Conventional60ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? ConventionalPintInventory { get; set; }
        [Display(Name = " ")]
        public int? ConventionalPintShipped { get; set; }
        [Display(Name = " ")]
        public decimal? ConventionalPintPrice { get; set; }
        [Display(Name = " ")]
        public int? ConventionalPintConsigned { get; set; }
        [Display(Name = " ")]
        public int? Conventional18ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Conventional18ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Conventional18ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Conventional18ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Conventional24ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Conventional24ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Conventional24ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Conventional24ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Conventional18_18ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Conventional18_18ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Conventional18_18ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Conventional18_18ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Conventional2lbInventory { get; set; }
        [Display(Name = " ")]
        public int? Conventional2lbShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Conventional2lbPrice { get; set; }
        [Display(Name = " ")]
        public int? Conventional2lbConsigned { get; set; }
        [Display(Name = " ")]
        public int? Conventional25lbInventory { get; set; }
        [Display(Name = " ")]
        public int? Conventional25lbShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Conventional25lbPrice { get; set; }
        [Display(Name = " ")]
        public int? Conventional25lbConsigned { get; set; }
        [Display(Name = " ")]
        public int? ConventionalOtherInventory { get; set; }
        [Display(Name = " ")]
        public int? ConventionalOtherShipped { get; set; }
        [Display(Name = " ")]
        public decimal? ConventionalOtherPrice { get; set; }
        [Display(Name = " ")]
        public int? ConventionalOtherConsigned { get; set; }
        [Display(Name = " ")]
        public int? Organic44ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Organic44ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Organic44ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Organic44ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Organic60ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Organic60ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Organic60ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Organic60ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? OrganicPintInventory { get; set; }
        [Display(Name = " ")]
        public int? OrganicPintShipped { get; set; }
        [Display(Name = " ")]
        public decimal? OrganicPintPrice { get; set; }
        [Display(Name = " ")]
        public int? OrganicPintConsigned { get; set; }
        [Display(Name = " ")]
        public int? Organic18ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Organic18ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Organic18ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Organic18ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Organic24ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Organic24ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Organic24ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Organic24ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Organic18_18ozInventory { get; set; }
        [Display(Name = " ")]
        public int? Organic18_18ozShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Organic18_18ozPrice { get; set; }
        [Display(Name = " ")]
        public int? Organic18_18ozConsigned { get; set; }
        [Display(Name = " ")]
        public int? Organic2lbInventory { get; set; }
        [Display(Name = " ")]
        public int? Organic2lbShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Organic2lbPrice { get; set; }
        [Display(Name = " ")]
        public int? Organic2lbConsigned { get; set; }
        [Display(Name = " ")]
        public int? Organic25lbInventory { get; set; }
        [Display(Name = " ")]
        public int? Organic25lbShipped { get; set; }
        [Display(Name = " ")]
        public decimal? Organic25lbPrice { get; set; }
        [Display(Name = " ")]
        public int? Organic25lbConsigned { get; set; }
        [Display(Name = " ")]
        public int? OrganicOtherInventory { get; set; }
        [Display(Name = " ")]
        public int? OrganicOtherShipped { get; set; }
        [Display(Name = " ")]
        public decimal? OrganicOtherPrice { get; set; }
        [Display(Name = " ")]
        public int? OrganicOtherConsigned { get; set; }

        // ReSharper restore InconsistentNaming

        #endregion
    }
}
