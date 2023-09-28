using System.ComponentModel.DataAnnotations;

namespace blogsite.webapp.Models
{
    public class BlogModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Zorunlu Alan!")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage ="Zorunlu Alan!")]
        public string Title { get; set; }


        [Required(ErrorMessage ="Zorunlu Alan!")]
        public string Content { get; set; }

        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NumberOfClicks { get; set; }
    }
}