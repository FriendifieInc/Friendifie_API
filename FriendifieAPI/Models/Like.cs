using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendifieAPI.Models
{
    public class Like
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("UserModel")]
        public string UserId { get; set; }

        // this "int" is because it's PREDEFINED in Post.cs's primary key property
        public int PostId { get; set; }
    }
}