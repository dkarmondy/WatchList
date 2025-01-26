namespace WatchList.Dtos
{
    public class WatchDto
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

// CREATE TABLE Watches (
//     Id INT PRIMARY KEY IDENTITY,
//     Brand NVARCHAR(255),
//     Model NVARCHAR(255),
//     Price DECIMAL(18, 2),
//     ImageUrl NVARCHAR(255),
//     DateAdded DATETIME
// );

// CREATE TABLE Users (
//     Id INT PRIMARY KEY IDENTITY,
//     Email NVARCHAR(255) UNIQUE,
//     PasswordHash NVARCHAR(255),
//     CreatedAt DATETIME
// );
