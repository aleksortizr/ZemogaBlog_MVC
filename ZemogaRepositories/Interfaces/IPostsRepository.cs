using Blog.DataAccess;
using Blog_Common;
using Blog_Common.DTOs;
using System.Collections.Generic;

namespace Blog_Repositories
{
    public interface IPostsRepository : IRepository<Post>
    {
        int Add(PostDTO post);

        bool ChangeStatus(int postId, PostStatuses status);

        new bool Delete(int postId);

        bool Update(PostDTO post);

        PostDTO Get(int postId);

        IEnumerable<PostDTO> GetUserPosts(int userId);

        IEnumerable<PostDTO> GetPendingPosts();

        IEnumerable<PostDTO> GetApprovedPosts();

        IEnumerable<PostDTO> Get();
    }
}
