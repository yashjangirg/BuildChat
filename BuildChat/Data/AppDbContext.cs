using BuildChat.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildChat.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TaskItems> TaskItems { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ProjectMembers> ProjectMembers { get; set; }
        public DbSet<TaskAssignment> TaskAssignment { get; set; }
    }
}
