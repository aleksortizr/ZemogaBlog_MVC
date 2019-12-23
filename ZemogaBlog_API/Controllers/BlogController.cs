using Blog_BusinessLogic.Services;
using Blog_Common.DTOs;
using Blog_Common.Requests;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogManager _blogManager;
        private readonly IDataContext _context;

        public BlogController(ILogger<BlogController> logger, IBlogManager blogManager, IDataContext context)
        {
            _context = context;
            _logger = logger;
            _blogManager = blogManager;
        }

        /// <summary>
        /// Gets the specific post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet]
        public PostDTO Get(int postId)
        {
            return _blogManager.GetPost(postId);
        }

        /// <summary>
        /// Endpoint to create a new post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromBody] CreatePostRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return _blogManager.AddPost(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error creating post.", null);
                }
            }

            return false;
        }

        /// <summary>
        /// Updates the post with a new text
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public bool Put([FromBody] UpdatePostRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return _blogManager.EditPost(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error editing post.", null);
                }
            }

            return false;
        }

        /// <summary>
        /// Deletes the specific post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool Delete(int postId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return _blogManager.DeletePost(postId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error editing post.", null);
                }
            }

            return false;
        }

        /// <summary>
        /// Get the list of post pending for audit
        /// </summary>
        /// <returns></returns>
        [HttpGet("PendingPosts")]
        public ActionResult PendingPosts()
        {
            try
            {
                var result = _blogManager.GetPendingPosts();
                return Ok(new JsonResult(result));
            }
            catch
            {
                _logger.LogError($"Error fetching the list of pending posts", null);
                return Conflict("$Error fetching the list of pending posts");
            }
        }

        /// <summary>
        /// Endpoint to approve / reject a post
        /// </summary>
        /// <param name="postId">Item to be approved / rejected</param>
        /// <param name="approvePost">true for approve; false to reject</param>
        /// <returns></returns>
        [HttpPost("ApprovePost")]
        public ActionResult ApprovePostPost(int postId, bool approvePost)
        {
            if(approvePost)
            {
                var result = _blogManager.ApprovePost(postId);
                if (result)
                    return Ok($"The post {postId} was successfully approved.");
                return Conflict($"There was a problem thrying to approve pst {postId}.");
            }
            else
            {
                var result = _blogManager.RejectPost(postId);
                if (result)
                    return Ok($"The post {postId} was successfully rejected.");
                return Conflict($"The post {postId} could not be rejected.");
            }
        }
    }
}