using Blog.DataAccess;
using Blog_Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        UserDTO Get(int userId);

        UserDTO Get(string userName);

        IEnumerable<UserDTO> Get();

        int Register(UserDTO request);

    }
}
