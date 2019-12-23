using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Common.DTOs
{
    public class CommentDTO
    {
        public int? UserId { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public int PostId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
