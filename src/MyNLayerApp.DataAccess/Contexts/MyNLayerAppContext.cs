using Microsoft.EntityFrameworkCore;

public class MyNLayerAppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MyNLayerDb;User Id=sa;Password=MssqlPass2026_X;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }
}