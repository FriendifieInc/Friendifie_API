using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendifieAPI.Models
{
    public class Customization
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // show other users if you're typing or not
        public bool Typing { get; set; }

        // show other users if you read their messages
        public bool HasRead { get; set; }

        // compact or spacious
        public bool Style { get; set; }

        // set an "enum" to select optional themes like woopr?
    }
}