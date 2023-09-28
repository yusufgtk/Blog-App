namespace blogsite.entity
{
    public class New
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}