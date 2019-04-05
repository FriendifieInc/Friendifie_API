using System;

namespace FriendifieAPI.ViewModels
{
    public class PostViewModel
    {
        public string Status { get; set; }

        public string UserID { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateTime { get; set; }
    }
}