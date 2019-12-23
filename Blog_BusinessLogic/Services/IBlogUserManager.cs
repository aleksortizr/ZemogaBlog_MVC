using Blog_Common.DTOs;
using Blog_Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_BusinessLogic.Services
{
    public interface IBlogUserManager
    {

        public UserDTO Authenticate(AuthenticationRequest request);

        public bool UserExists(string userName);

        public int Register(UserDTO user);
    }
}
