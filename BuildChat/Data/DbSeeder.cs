using BuildChat.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildChat.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();
            if(! dbContext.Roles.Any())
            {
                var roles = new List<Roles>
                {
                    new Roles{RoleName = "Admin"},
                    new Roles{ RoleName = "Developer"},
                    new Roles{RoleName = "Manager"}
                };
                await dbContext.AddRangeAsync(roles);
                await dbContext.SaveChangesAsync();

            }

            //Seed Users
            if (!dbContext.Users.Any())
            {
                var admin = new Users { UserName = "Admin User", UserEmail = "admin@system.com" 
                };
                await dbContext.AddAsync(admin);

                var adminRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == "Admin");

                //var newRoles = new UserRole { 
                //     UserId = admin.UserId,
                //     RoleId = adminRole.RoleId 
                //};

                var newRoles = new UserRole { 
                    Users = admin,
                    Roles = adminRole 
                };
                await dbContext.UserRoles.AddAsync(newRoles);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
