using FriendifieAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendifieAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Identities { get; set; }

        //Tables go here
        public DbSet<Post> Posts { get; set; }

        public DbSet<Like> Likes { get; set; }
    }
}