using Blog.DataAccess;
using Blog_Common.DTOs;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Repositories
{
    public class CommentsRepository : BaseRepository<Comment>, IRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(IDataContext context) : base(context)
        {

        }

        public int Add(CommentDTO comment)
        {
            return Add(new Comment
            {
                CreatedDate = DateTime.Now,
                PostId = comment.PostId,
                Text = comment.Text,
                UserId = comment.UserId,
                UserName = comment.UserName,
            });
        }
    }
}
