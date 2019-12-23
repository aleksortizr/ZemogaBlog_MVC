using Blog_Common.DTOs;
using Blog_Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_BusinessLogic.Services
{
    public interface IBlogManager
    {
        bool AddPost(CreatePostRequest request);

        IEnumerable<PostDTO> GetPosts();

        PostDTO GetPost(int postId);

        IEnumerable<PostDTO> GetUserPosts(string username);

        IEnumerable<PostDTO> GetPendingPosts();

        IEnumerable<PostDTO> GetApprovedPosts();

        bool EditPost(UpdatePostRequest request);

        bool DeletePost(int postId);

        bool SubmitPost(int postId);

        bool ApprovePost(int postId);

        bool RejectPost(int postId);

        bool SubmitComment(CommentDTO comment);
    }
}
