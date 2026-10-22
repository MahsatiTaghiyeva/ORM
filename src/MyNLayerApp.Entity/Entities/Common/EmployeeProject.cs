using System.ComponentModel.DataAnnotations.Schema;
public class EmployeeProject : BaseEntity
{
    [NotMapped]
    override public int Id { get=>base.Id; set => base.Id = value; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}