namespace cookieauth.domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public Samurai Samurai { get; set; } = null!;
        public int SamuraiId { get; set; }
    }
}