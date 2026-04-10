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
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    
    //Fluent API for many to many relationship between Users and Projects through ProjectMembers
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User
            modelBuilder.Entity<Users>(entitys =>
            {
                entitys.HasKey(e => e.UserId);
                entitys.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100);
                entitys.Property(e => e.UserEmail)
                .IsRequired()
                .HasMaxLength(150);
            });

            //Project
            modelBuilder.Entity<Projects>(entitys =>
            {
                entitys.HasKey(p => p.ProjectId);

                entitys.Property(p => p.ProjectName)
                        .IsRequired()
                        .HasMaxLength(200);

                entitys.Property(p => p.ProjectDescription)
                .HasMaxLength(1000);

                //Creator relationship (User --> Projects)
                entitys.HasOne(p => p.Creator)
                        .WithMany(p => p.Projects)
                        .HasForeignKey(p => p.CreatorId)
                        .OnDelete(DeleteBehavior.Restrict);
            });

            //TaskItems
            modelBuilder.Entity<TaskItems>(entitys =>
            {
                entitys.HasKey(p => p.TaskItemId);

                entitys.Property(p => p.Title)
                        .IsRequired()
                        .HasMaxLength(200);

                entitys.Property(p => p.Status)
                        .HasMaxLength(1000);
                //Creator relationship (User --> TaskItems)
                entitys.HasOne(p => p.Creator)
                        .WithMany(u => u.TaskItems)
                        .HasForeignKey(t => t.CreatorId)
                        .OnDelete(DeleteBehavior.Restrict);
                //Project relationship (Projects --> TaskItems)
                entitys.HasOne(p => p.Projects)
                        .WithMany(p => p.TaskItems)
                        .HasForeignKey(p => p.ProjectId)
                        .OnDelete(DeleteBehavior.Cascade);
            });


            //Comments
            modelBuilder.Entity<Comments>(entitys =>
            {
                entitys.HasKey(p => p.CommentId);

                entitys.Property(p => p.Content)
                        .IsRequired()
                        .HasMaxLength(1000);

                //User relationship (User --> Comments)
                entitys.HasOne(c => c.Users)
                        .WithMany(u => u.Comments)
                        .HasForeignKey(c => c.UserId)
                        .OnDelete(DeleteBehavior.Restrict);


                //TaskItems relationship (TaskItems --> Comments)
                entitys.HasOne(c => c.TaskItems)
                        .WithMany(t => t.Comments)
                        .HasForeignKey(c => c.TaskItemId)
                        .OnDelete(DeleteBehavior.Cascade);
                });

            //Project Members (Many to Many relationship between Users and Projects through ProjectMembers)
            modelBuilder.Entity<ProjectMembers>(entitys => {
                entitys.HasKey(pm => new {pm.UserId, pm.ProjectId });

                entitys.Property(pm => pm.Role)
                        .IsRequired()
                        .HasMaxLength(50);
                //User relationship (Users --> ProjectMembers)
                entitys.HasOne(pm => pm.Users)
                        .WithMany(u => u.ProjectMembers)
                        .HasForeignKey(pm => pm.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
                //Project relationship (Projects --> ProjectMembers)
                entitys.HasOne(pm => pm.Projects)
                        .WithMany(p => p.ProjectMembers)
                        .HasForeignKey(pm => pm.ProjectId)
                        .OnDelete(DeleteBehavior.Cascade);
            });

            //Task Assignment (Many to Many relationship between Users and TaskItems through TaskAssignment)
            modelBuilder.Entity<TaskAssignment>(entitys => {
                entitys.HasKey(ta => new {ta.UserId, ta.TaskItemId });

                //entitys.Property(ta => ta.AssignmentDate)
                //        .IsRequired();


                //User relationship (Users --> TaskAssignment)
                entitys.HasOne(ta => ta.Users)
                        .WithMany(u => u.TaskAssignments)
                        .HasForeignKey(ta => ta.UserId)
                        .OnDelete(DeleteBehavior.Cascade);
                //TaskItems relationship (TaskItems --> TaskAssignment)
                entitys.HasOne(ta => ta.TaskItems)
                        .WithMany(t => t.TaskAssignments)
                        .HasForeignKey(ta => ta.TaskItemId)
                        .OnDelete(DeleteBehavior.Cascade);
                });

            //Roles
            modelBuilder.Entity<Roles>(entitys => {
                entitys.HasKey(r => r.RoleId);

                entitys.Property(r => r.RoleName)
                        .IsRequired()
                        .HasMaxLength(50);
            });

            //UserRoles (Many to Many relationship between Users and Roles through UserRoles)
            modelBuilder.Entity<UserRole>(entitys => {
                entitys.HasKey(ur => new {ur.UserId, ur.RoleId });

                //User relationship (Users --> UserRoles)
                entitys.HasOne(ur => ur.Users)
                        .WithMany(u => u.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .OnDelete(DeleteBehavior.Cascade);

                //Roles relationship (Roles --> UserRoles)
                entitys.HasOne(ur => ur.Roles)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .OnDelete(DeleteBehavior.Cascade);
                 });
        }
    }

}
