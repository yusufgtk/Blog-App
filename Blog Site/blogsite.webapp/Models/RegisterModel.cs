using System.ComponentModel.DataAnnotations;

namespace blogsite.webapp.Models
{
    
    public class RegisterModel
    {
        [Required(ErrorMessage ="Zorunlu alan!")]
        public string FirstName { get; set; }


        [Required(ErrorMessage ="Zorunlu alan!")]
        public string LastName { get; set; }


        [Required(ErrorMessage ="Zorunlu alan!")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Zorunlu alan!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage ="Zorunlu alan!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Zorunlu alan!")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email formatında olması gerekiyor!")]
        public string EmailAddress { get; set; }

    }
}