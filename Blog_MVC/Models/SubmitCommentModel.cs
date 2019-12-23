using Blog_Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_MVC.Models
{
    public class SubmitCommentModel
    {
        public PostDTO Post { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Reply text is mandatory")]
        public string Text { get; set; }
    }
}
