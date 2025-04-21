using System;

namespace CarDealershipCatalog.Models
{
    public class Filter
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public bool? IsNew { get; set; }
    }
}