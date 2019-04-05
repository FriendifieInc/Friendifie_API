using Microsoft.AspNetCore.Mvc;

namespace FriendifieAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Lets create and endpoint here for example -> POST: Home/CreateProfile
        [HttpPost("[controller]/Profile")]
        public IActionResult CreateProfile()
        {
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}