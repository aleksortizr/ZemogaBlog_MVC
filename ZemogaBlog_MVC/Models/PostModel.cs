using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_MVC.Models
{
    public class PostModel
    {
        [Required(ErrorMessage = "Text is mandatory")]
        public string Text { get; set; }
    }
}
