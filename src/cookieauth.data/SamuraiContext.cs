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
    public DbSet<Samurai> Samurais => Set<Samurai>();
    public DbSet<Quote> Quotes => Set<Quote>();
    public DbSet<Battle> Battles => Set<Battle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Samurai>()
            .HasMany(s => s.Battles)
            .WithMany(b => b.Samurais)
            .UsingEntity<BattleSamurai>
                (
                    bs => bs.HasOne<Battle>().WithMany(),
                    bs => bs.HasOne<Samurai>().WithMany()
                );
        
        modelBuilder.Entity<BattleSamurai>()
            .Property(bs => bs.DateJoined).HasDefaultValueSql("getdate()");
    }
}
