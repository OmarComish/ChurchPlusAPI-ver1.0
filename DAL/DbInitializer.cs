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
                CreatedBy = 1, DateCreated = DateTime.UtcNow, Status = (int)RecordStatus.Active, 
                Email ="admin@codaflem.mw", MobileNumber ="3883383", CumulativeLogin = 0, RoleId = 1, UserName ="admin"}
            };
            context.AddRange(_users);
            context.SaveChanges();
            Console.WriteLine("Seeding user profile data completed successfully");
        }
        if(!context.CauseCategories.Any())
        {
            Console.WriteLine("Seeding user cause category data intiated...");
            var _causecategories = new List<CauseCategory>
            {
                new(){Id = 1, CauseName ="Church Building Project", CreatedBy = 1, 
                DateCreated = DateTime.UtcNow, Status = (int)RecordStatus.Active},
                 new(){Id = 2, CauseName ="Church Service Offering", CreatedBy = 1, 
                DateCreated = DateTime.UtcNow, Status = (int)RecordStatus.Active},
                 new(){Id = 5, CauseName ="Funeral Condolences", CreatedBy = 1, 
                DateCreated = DateTime.UtcNow, Status = (int)RecordStatus.Active},
                 new(){Id = 6, CauseName ="Love Offering", CreatedBy = 1, 
                DateCreated = DateTime.UtcNow, Status = (int)RecordStatus.Active}
            };
            context.AddRange(_causecategories);
            context.SaveChanges();
            Console.WriteLine("Seeding user cause category data complete");
        }
        if(!context.ChurchServiceSessions.Any())
        {
             Console.WriteLine("Seeding Church sessions data intiated...");
             var _churchsessions = new List<ChurchServiceSession>
             {
                 new(){Id =1, SessionName="Sunday service", CreatedBy = 1, 
                 DateCreated = DateTime.UtcNow, Status = RecordStatus.Active, },
                 new(){Id =2, SessionName="Wednesday service", CreatedBy = 1, 
                 DateCreated = DateTime.UtcNow, Status = RecordStatus.Active, },
                 new(){Id =3, SessionName="Friday service", CreatedBy = 1, 
                 DateCreated = DateTime.UtcNow, Status = RecordStatus.Active, }
             };

             context.AddRange(_churchsessions);
             context.SaveChanges();

             Console.WriteLine("Seeding Church sessions data complete");
        }
    }
}