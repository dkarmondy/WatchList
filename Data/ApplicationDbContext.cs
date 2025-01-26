using Microsoft.EntityFrameworkCore;
using WatchList.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Watch> Watch { get; set; }
    public DbSet<User> User { get; set; }
}
