
using System.ComponentModel.DataAnnotations;

namespace Blog_MVC.Models
{
    public class RegisterExternalModel
    {
        [Required(ErrorMessage = "UserName is mandatory")]
        public string UserName { get; set; }
    }
}