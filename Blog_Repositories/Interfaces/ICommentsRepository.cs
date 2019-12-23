using Blog.DataAccess;
using Blog_Common.DTOs;

namespace Blog_Repositories
{
    public interface ICommentsRepository : IRepository<Comment>
    {
        public int Add(CommentDTO comment);
    }
}