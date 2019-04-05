using FriendifieAPI.Models;
using FriendifieAPI.Services.Interfaces;
using FriendifieAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FriendifieAPI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthManager _authManager;

        public AccountController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost("Register"), AllowAnonymous]
        public IActionResult Register([FromBody] RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Hacker hacker go away!");

            return View();
        }
    }
}