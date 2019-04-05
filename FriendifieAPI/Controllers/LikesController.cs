using Microsoft.AspNetCore.Mvc;

namespace FriendifieAPI.Controllers
{
    [Route("Likes")]
    public class LikesController : Controller
    {
        [HttpGet("")]
        public IActionResult GetAllLikes()
        {
            return Ok("Getting /Likes/");
        }

        [HttpPost("{status_id}/{id}")]
        public IActionResult LikePost([FromBody]string status_id, int id)
        {
            return Ok("Getting /Likes/" + status_id + "/" + id);
        }
    }
}