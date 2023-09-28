using System.ComponentModel.DataAnnotations;

namespace blogsite.webapp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Zorunlu alan!")]
        public string Name { get; set; }
    }
}