using System.ComponentModel.DataAnnotations;

namespace FriendifieAPI.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}