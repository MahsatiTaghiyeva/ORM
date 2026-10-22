using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.StartDate).IsRequired();
        builder.Property(p => p.EndDate).IsRequired(false);
        builder.Property(p => p.Budget).IsRequired().HasPrecision(18, 2);
        builder.Property(p => p.CreatedAt)
        .IsRequired()
        .HasDefaultValueSql("GETDATE()");
    }
}