namespace blogsite.entity
{
    public class Blog
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NumberOfClicks { get; set; }
    }
}