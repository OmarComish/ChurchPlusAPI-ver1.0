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
    }
}