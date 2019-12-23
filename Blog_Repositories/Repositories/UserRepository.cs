using Blog.DataAccess;
using Blog_Common.DTOs;
using LinqToDB;
using LinqToDB.Data;
using System.Collections.Generic;
using System.Linq;

namespace Blog_Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>, IUsersRepository
    {
        public UserRepository(IDataContext context) : base(context)
        {
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
        }

        public UserDTO Get(int userId)
        {
            var result = FindById(userId);
            return Mapping.Mapper.Map<UserDTO>(result);
        }

        public UserDTO Get(string userName)
        {
            _dbSet = _dbContext.GetTable<User>().LoadWith(x => x.Role);
            var count = (from user in _dbSet
                         where user.UserName.ToLower() == userName.ToLower()
                         select user).Count();

            if (count <= 0)
                return null;
            var result = (from user in _dbSet
                          where user.UserName.ToLower().Equals(userName.ToLower())
                          select user).First();
            return Mapping.Mapper.Map<UserDTO>(result);
        }

        public IEnumerable<UserDTO> Get()
        {
            _dbSet = _dbContext.GetTable<User>().LoadWith(x => x.Role);
            var result = List(null, null);
            return Mapping.Mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public int Register(UserDTO request)
        {
            return Add(new User
            {
                Password = request.Password,
                RoleId = 1,
                UserName = request.UserName
            });
        }
    }
}
