
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPICourse.Constants;
using WebAPICourse.Models;

namespace WebAPICourse.Data;

public class AppDBContext:IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

        builder.Entity<Portfolio>()
            .HasOne(p => p.AppUser)
            .WithMany(p => p.Portfolios)
            .HasForeignKey(p => p.AppUserId);

        builder.Entity<Portfolio>()
            .HasOne(p => p.Stock)
            .WithMany(p => p.Portfolios)
            .HasForeignKey(p => p.StockId);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name= IdentityRolesValues.ADMIN,
                NormalizedName= IdentityRolesValues.ADMIN.ToUpper()
            },
            new IdentityRole
            {
                Name=IdentityRolesValues.USER,
                NormalizedName=IdentityRolesValues.USER.ToUpper(),
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}
