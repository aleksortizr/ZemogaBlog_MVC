using Blog_Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_MVC.Models
{
    public class UserPostsModel
    {
        public string UserName { get; set; }
        public IEnumerable<PostDTO> UserPosts { get; set; }
    }
}
