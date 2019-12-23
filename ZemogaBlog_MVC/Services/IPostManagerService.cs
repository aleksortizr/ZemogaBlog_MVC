
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
        Task<bool> CreatePost(string userId, string text);

        Task<IEnumerable<PostDTO>> UserPosts(string userId);

        Task<IEnumerable<PostDTO>> PendingPosts();

        Task<IEnumerable<PostDTO>> ApprovedPosts();

        Task<PostDTO> GetPostById(int postId);

        Task<bool> UpdatePost(PostDTO post);

        Task<bool> SubmitPost(int postId);

        Task<bool> Approve(int postId);

        Task<bool> Reject(int postId);

        Task<bool> Delete(int postId);

        Task<bool> SubmitComment(Blog_Common.DTOs.CommentDTO comment);
    }
}