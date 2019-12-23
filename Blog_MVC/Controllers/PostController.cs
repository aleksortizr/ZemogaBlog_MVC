using Blog_Common.DTOs;
using Blog_MVC.Models;
using Blog_MVC.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog_MVC.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostManagerService _postManagerService;
        private readonly IDataContext _context;

        public PostController(ILogger<PostController> logger, IPostManagerService userService, IDataContext context)
        {
            _context = context;
            _postManagerService = userService;
            _logger = logger;
        }

        [Authorize]
        public IActionResult CreatePost()
        {
            return View(new PostModel());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;

            if (!await _postManagerService.CreatePost(userName, model.Text))
            {
                ModelState.AddModelError("Error creating the post", "Could not validate your credentials");
                return View(model);
            }

            return RedirectToAction("Index", "UserPosts");
        }

        [Route("approvedposts")]
        [AllowAnonymous]
        public IActionResult ApprovedPosts()
        {
            var userPosts = _postManagerService.ApprovedPosts().Result;
            return View(new EditorPostsModel { UserName = "Anonymous", UserPosts = userPosts });
        }

        [Route("submitcomment")]
        [AllowAnonymous]
        public IActionResult SubmitComment(int postId)
        {
            var loggedInUser = User.Identity.IsAuthenticated ? User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value : null;
            var userName = User.Identity.IsAuthenticated ? User.Claims.First(x => x.Type == ClaimTypes.Name).Value : "Anonymous";
            var userPost = _postManagerService.GetPostById(postId).Result;
            if (userPost == null)
                return View();
            return View(new SubmitCommentModel
            {
                Post = userPost,
                UserId = (!string.IsNullOrEmpty(loggedInUser)) ? int.Parse(loggedInUser) : (int?)null,
                UserName = userName
            });
        }

        [Route("submitcomment")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SubmitComment([Bind] SubmitCommentModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(_postManagerService.SubmitComment(new CommentDTO
            {
                CreatedDate = DateTime.Now,
                PostId = model.Post.Id,
                Text = model.Text,
                UserId = model.UserId,
                UserName = model.UserName
            }).Result)
                return RedirectToAction("ApprovedPosts", "Post");
            return View(model);
        }
    }
}