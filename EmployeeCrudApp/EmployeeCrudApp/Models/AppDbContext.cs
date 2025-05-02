using EmployeeCrudApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

   
    public DbSet<Employee> Employees { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
           v => v.ToUniversalTime(),  
           v => DateTime.SpecifyKind(v, DateTimeKind.Utc) 
         );
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(dateTimeConverter);
                }
            }
        }

       
        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email) 
            .IsUnique();  

        modelBuilder.Entity<Employee>()
            .Property(e => e.Name)
            .HasMaxLength(100); 
    }

  
}
