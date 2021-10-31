using cookieauth.data;
using cookieauth.domain;

var isCreated = Utility.IsCreated;
Utility.GetSamurais("Before Add:");
Utility.AddSamurai();
Utility.GetSamurais("After Add:");

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
    public static void GetSamurais(string text)
    {
        var samurais = _context.Samurais.ToList();

        Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
        foreach (var samurai in samurais)
        {
            Console.WriteLine(samurai.Name);
        }
    }
}

