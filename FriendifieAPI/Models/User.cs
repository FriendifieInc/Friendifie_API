using Microsoft.AspNetCore.Identity;

namespace FriendifieAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EmailCode { get; set; }
    }
}