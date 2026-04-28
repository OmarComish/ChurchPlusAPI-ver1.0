using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.Application.Services;
using ChurchPlusAPI_v1._0.RequestHelpers;
using ChurchPlusAPI_v1.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<IPledges, PledgeService>();
builder.Services.AddTransient<IOffering, OfferingService>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddDbContext<DataContext>(options=>{

    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

  /* opt.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version(8,0,29)))
   .LogTo(Console.WriteLine, LogLevel.Information)
   .EnableSensitiveDataLogging()
   .EnableDetailedErrors();*/
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

try
{
    DbInitializer.DbInit(app);
}
catch(Exception e)
{
    Console.WriteLine(e);
}

app.Run();


