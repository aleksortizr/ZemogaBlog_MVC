using Blog_MVC.Models;
using Blog_MVC.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;

namespace Blog_MVC.Controllers
{
    [Route("controller")]
    public class EditorController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostManagerService _postManagerService;
        private readonly IDataContext _context;

        public EditorController(ILogger<PostController> logger, IPostManagerService userService, IDataContext context)
        {
            _context = context;
            _postManagerService = userService;
            _logger = logger;
        }

        [Route("editorposts")]
        [Authorize(Roles = "Editor")]
        public IActionResult Index()
        {
            var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
            var userPosts = _postManagerService.PendingPosts();
            return View(new EditorPostsModel { UserName = userName, UserPosts = userPosts.Result });
        }

        [Route("editorapprove")]
        [Authorize]
        public IActionResult Approve(int postId)
        {
            if (!_postManagerService.Approve(postId).Result)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [Route("editorreject")]
        [Authorize]
        public IActionResult Reject(int postId)
        {
            if (!_postManagerService.Reject(postId).Result)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [Route("editordelete")]
        [Authorize]
        public IActionResult Delete(int postId)
        {
            if (!_postManagerService.Delete(postId).Result)
            {
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}