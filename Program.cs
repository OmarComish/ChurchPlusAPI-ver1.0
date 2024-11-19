using ChurchPlusAPI_v1._0.BusinessLogic;
using ChurchPlusAPI_v1._0.DAL;
using ChurchPlusAPI_v1.DAL;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt=>{
   opt.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version(8,0,29)))
   .LogTo(Console.WriteLine, LogLevel.Information)
   .EnableSensitiveDataLogging()
   .EnableDetailedErrors();
});

builder.Services.AddTransient<IOfferings,OfferingRepository>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

try
{    
   DbInitializer.InitDb(app);
}
catch(Exception e)
{
   Console.WriteLine(e.Message);
}

app.Run();


