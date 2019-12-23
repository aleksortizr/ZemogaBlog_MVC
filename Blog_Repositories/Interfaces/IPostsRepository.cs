using Blog.DataAccess;
using Blog_Common;
using Blog_Common.DTOs;
using System.Collections.Generic;

namespace Blog_Repositories
{
    public interface IPostsRepository : IRepository<Post>
    {
        public int Add(PostDTO post);

        public bool ChangeStatus(int postId, PostStatuses status);

        public new bool Delete(int postId);

        public bool Update(PostDTO post);

        public PostDTO Get(int postId);

        public IEnumerable<PostDTO> GetUserPosts(int userId);

        public IEnumerable<PostDTO> GetPendingPosts();

        public IEnumerable<PostDTO> GetApprovedPosts();

        public IEnumerable<PostDTO> Get();
    }
}
