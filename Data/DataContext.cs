using Microsoft.EntityFrameworkCore;

namespace shereeni_dotnet.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    // we can also use the app settings file to configure/add connection strings
    // and then register this thing in the program.cs
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    //     // in EF 7 we need to add this one also => TrustServerCertificate= true
    //     optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=shereeni;Trusted_Connection=true;TrustServerCertificate=true");
    // }

    public DbSet<User> Users { get; set; }
} 