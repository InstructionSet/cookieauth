using cookieauth.data;
using cookieauth.domain;
using Microsoft.EntityFrameworkCore;

var isCreated = Utility.IsCreated;
// Utility.GetSamurais("Before Add:");
// Utility.AddSamuraisByName("Julie","Sampson");
// Utility.AddSamuraisByName("Shimada","Okamoto","Kikuchio","Hayashida");
// Utility.GetSamurais("After Add:");
// Utility.QueryFilters();
// Utility.QueryAggregates();
Utility.RetrieveAndUpdateBatch();

public static class Utility
{
    private static SamuraiContext _context = new SamuraiContext();

    public static bool IsCreated { 
        get 
        {
            return _context.Database.EnsureCreated();
        } 
    }

    public static void AddSamurai()
    {
        var samurai = new Samurai { Name = "Sampson" };

        _context.Samurais.Add(samurai);
        _context.SaveChanges();

    }

    public static void AddSamuraisByName(params string[] names)
    {
        foreach (string name in names)
        {
            _context.Samurais.Add(new Samurai { Name = name });
        }
        _context.SaveChanges();
    }

    public static void GetSamurais(string text)
    {
        var samurais = _context.Samurais.TagWith("GetSamurais method").ToList();

        Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
        foreach (var samurai in samurais)
        {
            Console.WriteLine(samurai.Name);
        }
    }

    public static void QueryFilters()
    {
        var samurais = _context.Samurais
                            .Where(s => EF.Functions.Like(s.Name, "J%")).ToList();
    }

    public static void QueryAggregates()
    {
        //var name = "Sampson";
        var samurai = _context.Samurais
                            .Find(14);
    }

    public static void RetrieveAndUpdateSamurai()
    {
        var samurai = _context.Samurais.First();
        samurai.Name += "San";
        _context.SaveChanges();
    }
    
    public static void RetrieveAndUpdateBatch()
    {
        var samurais = _context.Samurais.Skip(1).Take(4).ToList();
        samurais.ForEach(x => x.Name += "San");
        _context.SaveChanges();
    }
}
