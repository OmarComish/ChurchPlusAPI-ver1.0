using ChurchPlusAPI_v1._0.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlusAPI_v1.DAL;

public class DbInitializer
{
    public static void DbInit(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        SeedData(scope.ServiceProvider.GetService<DataContext>());
    }

    private static void SeedData(DataContext context)
    {
        context.Database.Migrate();
        if(!context.Users.Any())
        {
            Console.WriteLine("Seeding user profile data intiated...");
            var _users = new List<User>
            {
                new () {FirstName ="Admin", MiddleNme ="SuperUser", LastName ="Admin", ChurchLocation =1,
                CreatedBy = 1, DateCreated = DateTime.UtcNow, Status = 1, 
                Email ="admin@codaflem.mw", MobileNumber ="3883383", CumulativeLogin = 0, RoleId = 1, UserName ="admin"}
            };
            context.AddRange(_users);
            context.SaveChanges();
            Console.WriteLine("Seeding user profile data completed successfully!");
        }
    }
}