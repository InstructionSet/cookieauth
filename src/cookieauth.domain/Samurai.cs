namespace cookieauth.domain {
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Quote> Quotes { get; set; } = new List<Quote>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}