using Blog_BusinessLogic.Services;
using Blog_Common.DTOs;
using Blog_Common.Requests;
using Blog_Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_BusinessLogic
{
    public class BlogUserManager : IBlogUserManager
    {
        private readonly IUsersRepository _usersRepository;
        public BlogUserManager(IUsersRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public UserDTO Authenticate(AuthenticationRequest request)
        {
            var user = _usersRepository.Get(request.UserName);
            if (user == null)
                return null;

            if (user.Password.Equals(request.Password, StringComparison.InvariantCultureIgnoreCase))
                return user;
            return null;
        }

        public bool UserExists(string userName)
        {
            return _usersRepository.Get(userName) != null;
        }

        public int Register(UserDTO user)
        {
            return _usersRepository.Register(user);
        }
    }
}
