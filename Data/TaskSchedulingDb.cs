using Microsoft.EntityFrameworkCore;
using TaskScheduling.Mappings;
using TaskScheduling.Models;

namespace TaskScheduling.Data;

public class TaskSchedulingDb : DbContext
{
    
    public DbSet<TaskModel> Tasks { get; set; }

    public TaskSchedulingDb(DbContextOptions options) : base(options)
    {
    }

    public TaskSchedulingDb()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configRoot = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //replace appsettings.Development.json with appsettings.json
            .AddJsonFile("appsettings.Development.json")
            .Build();
        optionsBuilder.UseSqlServer(configRoot.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskMap());
    }
}


