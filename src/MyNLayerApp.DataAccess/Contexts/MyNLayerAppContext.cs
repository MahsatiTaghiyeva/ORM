
using Microsoft.EntityFrameworkCore;

public class MyNLayerAppContext : DbContext
{
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=.\SQLEXPRESS;Database=MyNLayerDb;Integrated Security=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
