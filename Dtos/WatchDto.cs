namespace WatchList.Dtos
{
    public class WatchDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } 
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
