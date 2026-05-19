using ChurchPlusAPI_v1._0.Application.Interfaces;
using ChurchPlusAPI_v1._0.Application.Services;
using ChurchPlusAPI_v1._0.RequestHelpers;
using ChurchPlusAPI_v1.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>opt.AddPolicy("ApiCordsPolicy", options => options.AllowAnyOrigin()
.AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddTransient<IPledges, PledgeService>();
builder.Services.AddTransient<IOffering, OfferingService>();
builder.Services.AddTransient<IExpenses, ExpenseService>();
builder.Services.AddHttpClient<IApiService, ApiService>();
builder.Services.AddTransient<IAuthentication, AuthenticationService>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddDbContext<DataContext>(options=>{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

  /* opt.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),new MySqlServerVersion(new Version(8,0,29)))
   .LogTo(Console.WriteLine, LogLevel.Information)
   .EnableSensitiveDataLogging()
   .EnableDetailedErrors();*/
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServiceUrl"];
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters.ValidateAudience = false;
    options.TokenValidationParameters.NameClaimType ="username";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context =>
        {
            var scopeClaim = context.User.FindFirst("scope")?.Value;
            return scopeClaim != null && scopeClaim.Split(' ').Contains("casemanagement");
        });
    });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("ApiCorsPolicy");
app.MapControllers();
app.UseHttpsRedirection();
app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});


try
{
    DbInitializer.DbInit(app);
}
catch(Exception e)
{
    Console.WriteLine(e);
}

app.Run();


