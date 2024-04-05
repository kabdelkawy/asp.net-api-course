
using Microsoft.EntityFrameworkCore;
using WebAPICourse.Models;

namespace WebAPICourse.Data;

public class AppDBContext:DbContext
{
    public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
