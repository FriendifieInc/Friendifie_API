using System;
using System.Linq;
using System.Security.Claims;
using FriendifieAPI.Data;
using FriendifieAPI.Models;
using FriendifieAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendifieAPI.Controllers
{
    //[Authorize]
    [Route("Posts")]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _database;

        public PostsController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpGet(""), AllowAnonymous]
        public IActionResult GetAllPosts()
        {
            var allPosts = _database.Posts
                .Where(x => x.Deleted == false)
                .ToList();
            return Ok(allPosts);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost([FromRoute] int id, [FromBody]UpdatePostViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad request");

            var dbPost = _database.Posts.FirstOrDefault(x => x.Id == id);
            if (dbPost == null)
                return BadRequest("Invalid.....");

            if (dbPost.Deleted == true)
                return BadRequest("fdjkhfkjshdkf");

            dbPost.Status = model.Status;
            _database.Posts.Update(dbPost);
            _database.SaveChanges();
            return Ok(dbPost);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost([FromRoute] int id)
        {
            //check if the post coming from frontend is owned(created) by the current user
            var dbPost = _database.Posts.FirstOrDefault(x => x.Id == id);
            if (dbPost == null)
                return BadRequest("not there");

            dbPost.Deleted = true;
            _database.Posts.Update(dbPost);
            _database.SaveChanges();
            return Ok();

            //
            //_database.Posts.Where(x => x.Id == id).OrderByDescending(x => x.DateTime).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult ShowStatus(int id)
        {
            //$myvariable = new Post();
            var myVariable = new Post();
            myVariable.Id = id;
            myVariable.Status = "You've selected post: " + id;
            myVariable.DateTime = DateTime.Now;
            myVariable.UserId = Guid.NewGuid().ToString();
            return Ok(myVariable);
            //return Ok(id + " " + post);
        }

        [HttpPost("Create")]
        public IActionResult PostStatus([FromBody]CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Hacker hacker go away!");

            var currentUserId = GetCurrentUserId();
            var newPost = new Post()
            {
                DateTime = DateTime.UtcNow,
                Status = model.Status,
                UserId = Guid.NewGuid().ToString()//currentUserId
            };
            _database.Posts.Add(newPost);
            _database.SaveChanges();
            return Ok(newPost);
        }

        private string GetCurrentUserId()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                return claim.Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}