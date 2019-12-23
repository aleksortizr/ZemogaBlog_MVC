using Blog.DataAccess;
using Blog_Common;
using Blog_Common.DTOs;
using LinqToDB;
using System;
using System.Data.Linq;
using System.Collections.Generic;

namespace Blog_Repositories
{
    public class PostsRepository : BaseRepository<Post>, IRepository<Post>, IPostsRepository
    {
        public PostsRepository(IDataContext context) : base(context)
        {
            
        }

        public int Add(PostDTO post)
        {
            return Add(new Post
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                StatusId = (int)PostStatuses.Created,
                Text = post.Text,
                UserId = post.UserId
            });
        }

        public bool Update(PostDTO post)
        {
            return Update(new Post
            {
                Id = post.Id,
                CreatedDate = post.CreatedDate,
                StatusId = (int) PostStatuses.Created,
                Text = post.Text,
                UserId = post.UserId,
                UpdatedDate = DateTime.Now
            });
        }

        public PostDTO Get(int postId)
        {
            var result = FindById(postId);
            return Mapping.Mapper.Map<PostDTO>(result);
        }

        public IEnumerable<PostDTO> Get()
        {
            var result = List(null, null);
            return Mapping.Mapper.Map<IEnumerable<PostDTO>>(result);
        }

        public IEnumerable<PostDTO> GetUserPosts(int userId)
        {
            var result = List(x => x.UserId == userId, null);
            return Mapping.Mapper.Map<IEnumerable<PostDTO>>(result);
        }

        public bool ChangeStatus(int postId, PostStatuses status)
        {
            Post post = FindById(postId);

            if (post != null)
            {
                post.StatusId = (int)status;
                if (status == PostStatuses.Approved)
                    post.ApprovalDate = DateTime.Now;
                return Update(post);
            }
            return false;
        }

        bool IPostsRepository.Delete(int postId)
        {
            return Delete(postId);
        }

        public IEnumerable<PostDTO> GetPendingPosts()
        {
            var result = List(x => x.StatusId == (int)PostStatuses.Pending, null);
            return Mapping.Mapper.Map<IEnumerable<PostDTO>>(result);
        }

        public IEnumerable<PostDTO> GetApprovedPosts()
        {
            LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
            _dbSet = _dbContext.GetTable<Post>().LoadWith(x => x.User).LoadWith(x => x.Comments);
            var result = List(x => x.StatusId == (int)PostStatuses.Approved, null);
            return Mapping.Mapper.Map<IEnumerable<PostDTO>>(result);
        }
    }
}
