using ChurchPlusAPI_v1._0.Models;
using ChurchPlusAPI_v1.DAL;
using Microsoft.EntityFrameworkCore;

namespace ChurchPlusAPI_v1._0.DAL;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        SeedData(scope.ServiceProvider.GetService<DataContext>());
    }

    private static void SeedData(DataContext context)
    {
        context.Database.Migrate();
        
        if(context.UserRoles.Any())
        {
            return;
        }
        var userroles = new List<UserRole>()
        {
            new UserRole{ Id = 1, Name= "ADMIN", CreatedBy = 1, DateCreated = DateTime.UtcNow},
            new UserRole{ Id = 2, Name= "TRUSTEE", CreatedBy = 1, DateCreated = DateTime.UtcNow},
            new UserRole{ Id = 3, Name= "TREASURER", CreatedBy = 1, DateCreated = DateTime.UtcNow},
            new UserRole{ Id = 4, Name= "STANDARD", CreatedBy = 1, DateCreated = DateTime.UtcNow},

        };
        context.AddRange(userroles);
        context.SaveChanges();

        if(context.UserRoles.Any())
        {
            return;
        }
        var recordstatuses = new List<RecordStatus>()
        {
           new RecordStatus{ Id = 1, Name="Approved", CreatedBy = 1, DateCreated = DateTime.UtcNow},
           new RecordStatus{ Id = 2, Name="Active", CreatedBy = 1, DateCreated = DateTime.UtcNow},
           new RecordStatus{ Id = 3, Name="Disabled", CreatedBy = 1, DateCreated = DateTime.UtcNow},
           new RecordStatus{ Id = 4, Name="Rejected", CreatedBy = 1, DateCreated = DateTime.UtcNow},
           new RecordStatus{ Id = 5, Name="Pending", CreatedBy = 1, DateCreated = DateTime.UtcNow},
        };
        context.AddRange(recordstatuses);
        context.SaveChanges();

        if(context.OfferingGroups.Any())
        {
            return;
        }
        var offeringgroups = new List<OfferingGroup>()
        {
           new OfferingGroup{Id = 1, GroupName="Love offering", CreatedBy = 1, DateCreated =DateTime.UtcNow},
           new OfferingGroup{Id = 2, GroupName="General offering", CreatedBy = 1, DateCreated =DateTime.UtcNow}
        };

        context.AddRange(offeringgroups);
        context.SaveChanges();

    }
}