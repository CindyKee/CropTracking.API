using System;

namespace CropTracking.API.Models
{
    public class DailyInformation
    {
        public DailyInformation()
        {
            PackShipDate = DateTime.Today;
            ReportDate = DateTime.Now;
        }

        public int DailyInformationId { get; set; }

        public DateTime PackShipDate { get; set; }

        public DateTime ReportDate { get; set; }

        public DateTime? ProcessDate { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        // TODO: After EF is added: Change this to Fluent configurations
        //[Column(TypeName = "timestamp")]
        //[MaxLength(8)]
        //[Timestamp]
        //public byte[] RowVersionCol { get; set; }

        // ReSharper disable InconsistentNaming
        public int? Conventional44ozInventory { get; set; }

        public int? Conventional44ozShipped { get; set; }

        public decimal? Conventional44ozPrice { get; set; }

        public int? Conventional44ozConsigned { get; set; }

        public int? Conventional60ozInventory { get; set; }

        public int? Conventional60ozShipped { get; set; }

        public decimal? Conventional60ozPrice { get; set; }

        public int? Conventional60ozConsigned { get; set; }

        public int? ConventionalPintInventory { get; set; }

        public int? ConventionalPintShipped { get; set; }

        public decimal? ConventionalPintPrice { get; set; }

        public int? ConventionalPintConsigned { get; set; }

        public int? Conventional18ozInventory { get; set; }

        public int? Conventional18ozShipped { get; set; }

        public decimal? Conventional18ozPrice { get; set; }

        public int? Conventional18ozConsigned { get; set; }

        public int? Conventional24ozInventory { get; set; }

        public int? Conventional24ozShipped { get; set; }

        public decimal? Conventional24ozPrice { get; set; }

        public int? Conventional24ozConsigned { get; set; }

        public int? Conventional18_18ozInventory { get; set; }

        public int? Conventional18_18ozShipped { get; set; }

        public decimal? Conventional18_18ozPrice { get; set; }

        public int? Conventional18_18ozConsigned { get; set; }

        public int? Conventional2lbInventory { get; set; }

        public int? Conventional2lbShipped { get; set; }

        public decimal? Conventional2lbPrice { get; set; }

        public int? Conventional2lbConsigned { get; set; }

        public int? Conventional25lbInventory { get; set; }

        public int? Conventional25lbShipped { get; set; }

        public decimal? Conventional25lbPrice { get; set; }

        public int? Conventional25lbConsigned { get; set; }

        public int? ConventionalOtherInventory { get; set; }

        public int? ConventionalOtherShipped { get; set; }

        public decimal? ConventionalOtherPrice { get; set; }

        public int? ConventionalOtherConsigned { get; set; }

        public int? Organic44ozInventory { get; set; }

        public int? Organic44ozShipped { get; set; }

        public decimal? Organic44ozPrice { get; set; }

        public int? Organic44ozConsigned { get; set; }

        public int? Organic60ozInventory { get; set; }

        public int? Organic60ozShipped { get; set; }

        public decimal? Organic60ozPrice { get; set; }

        public int? Organic60ozConsigned { get; set; }

        public int? OrganicPintInventory { get; set; }

        public int? OrganicPintShipped { get; set; }

        public decimal? OrganicPintPrice { get; set; }

        public int? OrganicPintConsigned { get; set; }

        public int? Organic18ozInventory { get; set; }

        public int? Organic18ozShipped { get; set; }

        public decimal? Organic18ozPrice { get; set; }

        public int? Organic18ozConsigned { get; set; }

        public int? Organic24ozInventory { get; set; }

        public int? Organic24ozShipped { get; set; }

        public decimal? Organic24ozPrice { get; set; }

        public int? Organic24ozConsigned { get; set; }

        public int? Organic18_18ozInventory { get; set; }

        public int? Organic18_18ozShipped { get; set; }

        public decimal? Organic18_18ozPrice { get; set; }

        public int? Organic18_18ozConsigned { get; set; }

        public int? Organic2lbInventory { get; set; }

        public int? Organic2lbShipped { get; set; }

        public decimal? Organic2lbPrice { get; set; }

        public int? Organic2lbConsigned { get; set; }

        public int? Organic25lbInventory { get; set; }

        public int? Organic25lbShipped { get; set; }

        public decimal? Organic25lbPrice { get; set; }

        public int? Organic25lbConsigned { get; set; }

        public int? OrganicOtherInventory { get; set; }

        public int? OrganicOtherShipped { get; set; }

        public decimal? OrganicOtherPrice { get; set; }

        public int? OrganicOtherConsigned { get; set; }

        // ReSharper restore InconsistentNaming
    }
}
