public class Project : AuditEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Budget { get; set; }
    public List<EmployeeProject> Employees { get; set; } 
    public Project()
    {
        Employees = new List<EmployeeProject>();
    }

}