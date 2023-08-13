using System.ComponentModel.DataAnnotations;

namespace PhotoBookWeb.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Please Enter UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }
    }
}
