using cookieauth.domain;
using Microsoft.EntityFrameworkCore;

namespace cookieauth.data;
public class SamuraiContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost; Database=SamuraiDb;User Id=sa;Password=pass!word;");
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Samurai>? Samurais {get; set;}
    public DbSet<Quote>? Quotes { get; set; }
}
