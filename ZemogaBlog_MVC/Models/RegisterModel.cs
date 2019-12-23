using System.ComponentModel.DataAnnotations;

namespace Blog_MVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "UserName is mandatory")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please type in a password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The repeat password did not seem correct")]
        public string RepeatPassword { get; set; }
    }
}