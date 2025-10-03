using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class AppDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}
