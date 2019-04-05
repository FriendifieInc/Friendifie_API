using System.ComponentModel.DataAnnotations;

namespace FriendifieAPI.ViewModels
{
    public class UpdatePostViewModel
    {
        [Required]
        public string Status { get; set; }
    }
}