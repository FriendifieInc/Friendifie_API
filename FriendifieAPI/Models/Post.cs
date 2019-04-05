using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendifieAPI.Models
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("UserModel")]
        public string UserId { get; set; }

        public string Status { get; set; }

        public DateTime DateTime { get; set; }

        public bool Deleted { get; set; }

        //public virtual User UserModel { get; set; }
    }
}