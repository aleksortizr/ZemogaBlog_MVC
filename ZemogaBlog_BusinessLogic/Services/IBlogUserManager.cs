using Blog_Common.DTOs;
using Blog_Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_BusinessLogic.Services
{
    public interface IBlogUserManager
    {

        UserDTO Authenticate(AuthenticationRequest request);

        bool UserExists(string userName);

        int Register(UserDTO user);
    }
}
