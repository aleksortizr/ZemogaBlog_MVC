
using Blog.DataAccess;
using Blog_Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog_MVC.Services
{
    public interface IPostManagerService
    {
        Task<UserDTO> Authenticate(string userName, string password);
        Task<UserDTO> Add(string username, string password);
        public Task<bool> CreatePost(string userId, string text);

        public Task<IEnumerable<PostDTO>> UserPosts(string userId);

        public Task<IEnumerable<PostDTO>> PendingPosts();

        public Task<IEnumerable<PostDTO>> ApprovedPosts();

        public Task<PostDTO> GetPostById(int postId);

        public Task<bool> UpdatePost(PostDTO post);

        public Task<bool> SubmitPost(int postId);

        public Task<bool> Approve(int postId);

        public Task<bool> Reject(int postId);

        public Task<bool> Delete(int postId);

        public Task<bool> SubmitComment(Blog_Common.DTOs.CommentDTO comment);
    }
}