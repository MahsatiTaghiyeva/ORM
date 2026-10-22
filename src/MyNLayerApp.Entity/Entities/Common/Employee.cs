public class Employee : AuditEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public List<EmployeeProject> EmployeeProjects { get; set; }
    public Employee()
    {
        EmployeeProjects = new List<EmployeeProject>();             
    }
}