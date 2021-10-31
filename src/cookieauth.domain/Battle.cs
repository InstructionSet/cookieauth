namespace cookieauth.domain {
    public class Battle {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Samurai> Samurais { get; set; } = new List<Samurai>();
    }
}