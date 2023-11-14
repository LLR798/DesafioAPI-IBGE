using Microsoft.EntityFrameworkCore;
using WebApiWithAuth.Models;

namespace WebApiWithAuth.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Location> Locations { get; set; }
}