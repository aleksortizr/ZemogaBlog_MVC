using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Common.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; } // int
        public string UserName { get; set; } // nvarchar(50)
        public string Password { get; set; } // nvarchar(50)
        public int? RoleId { get; set; } // int

        public string Role { get; set; }
    }
}
