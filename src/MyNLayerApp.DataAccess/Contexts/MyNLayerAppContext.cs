
using Microsoft.EntityFrameworkCore;

public class MyNLayerAppContext : DbContext
{
<<<<<<< HEAD
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=.\SQLEXPRESS;Database=MyNLayerDb;Integrated Security=True;TrustServerCertificate=True;");
=======
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<EmployeeProject> EmployeeProjects { get; set; } = null!;
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=MyNLayerDb;User Id=sa;Password=MssqlPass2026_X;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MyNLayerAppContext).Assembly);
>>>>>>> 46b326c (commit)
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
