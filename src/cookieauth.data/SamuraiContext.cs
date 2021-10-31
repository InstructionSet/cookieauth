using cookieauth.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace cookieauth.data;
public class SamuraiContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source=localhost; Database=SamuraiDb;User Id=sa;Password=pass!word;")
            .LogTo( Console.WriteLine, new []{ DbLoggerCategory.Database.Command.Name }, LogLevel.Information )
            .EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
    public DbSet<Samurai> Samurais => Set<Samurai>();
    public DbSet<Quote> Quotes => Set<Quote>();
    public DbSet<Battle> Battles => Set<Battle>();
    public DbSet<Horse> Horses => Set<Horse>();

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
