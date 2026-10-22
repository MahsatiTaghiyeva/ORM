using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(e => e.LastName)
            .HasMaxLength(50);
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);
        builder.Property(e => e.HireDate)
            .IsRequired();
        builder.Property(e => e.Salary)
            .IsRequired()
    .HasPrecision(18, 2);
        builder.Property(e => e.Status)
            .IsRequired()
            .HasDefaultValue(EmployeeStatus.Active);
        
        builder.HasIndex(e => e.Email)
            .IsUnique();
        builder.HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
