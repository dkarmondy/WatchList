namespace WatchList.Models
{
    public class Watch
    {
        public int WatchId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int SerialNumber { get; set; }
        public int YearMade { get; set; }
        public decimal PurchasePrice { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
