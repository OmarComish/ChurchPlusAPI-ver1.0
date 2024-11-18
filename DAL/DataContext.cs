using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql;
using ChurchPlusAPI_v1._0.Models;


namespace ChurchPlusAPI_v1.DAL;
public class DataContext: DbContext
{
    public DataContext(DbContextOptions options): base(options)
    {
          
    }
    public DbSet<AppLogs> AppLogs {get; set;}
    public DbSet<CauseCategory> CauseCategories {get; set;}
    public DbSet<Expense> Expenses {get; set;}
    public DbSet<Offering> Offerings {get; set;}
    public DbSet<OfferingGroup> OfferingGroups {get; set;}
    public DbSet<Pledge> Pledges {get; set;}
    public DbSet<Receipts> Receipts {get; set;}
    public DbSet<RecordStatus> RecordStatuses {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<UserRole> UserRoles {get; set;}
}