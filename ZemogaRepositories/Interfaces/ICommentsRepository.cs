using Blog.DataAccess;
using Blog_Common.DTOs;

namespace Blog_Repositories
{
    public interface ICommentsRepository : IRepository<Comment>
    {
        int Add(CommentDTO comment);
    }
}