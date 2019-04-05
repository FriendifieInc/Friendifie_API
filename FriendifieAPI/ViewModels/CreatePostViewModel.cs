using System.ComponentModel.DataAnnotations;

namespace FriendifieAPI.ViewModels
{
    public class CreatePostViewModel
    {
        [Required]
        public string Status { get; set; }

        [Required]
        public string Link { get; set; }
    }
}