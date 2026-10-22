using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeProjectConfiguration
    : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        // Composite primary key
        builder.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

        // Employee relationship
        builder.HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.EmployeeId);

        // Project relationship
        builder.HasOne(ep => ep.Project)
            .WithMany(p => p.Employees)
            .HasForeignKey(ep => ep.ProjectId);
    }
}