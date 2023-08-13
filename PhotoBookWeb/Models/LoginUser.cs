using System.ComponentModel.DataAnnotations;

namespace PhotoBookWeb.Models
{
    public class LoginUser
    {
        public LoginUser()
        {
        }
        [Required(ErrorMessage = "Please Enter User Name.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password.")]
        [Compare(nameof(Password), ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Required(ErrorMessage = "Please Enter Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter First Name.")]
        public string  FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number.")]
        public string Mobile { get; set; }
    }
}
