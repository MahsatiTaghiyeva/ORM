using Microsoft.EntityFrameworkCore;

public class DepartmentService
{
    private readonly MyNLayerAppContext _context;

    public DepartmentService(MyNLayerAppContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllDepartmentsAsync()
    {
        return await _context.Departments
            .Include(d => d.Employees)
            .ToListAsync();
    }

    public async Task<Department?> GetDepartmentByIdAsync(int? id)
    {
        if(id is null) throw new ArgumentNullException(nameof(id));
        var department = await _context.Departments.FindAsync(id);
        if (department == null) throw new KeyNotFoundException($"Department with ID {id} not found.");
        return department;
    }
    public async Task<Department> CreateDepartmentAsync(Department department)
    {
        if(department is null) throw new ArgumentNullException(nameof(department));
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(d => d.Name.ToLower() == department.Name.ToLower());
        if (existingDepartment != null) throw new InvalidOperationException($"Department with name '{department.Name}' already exists.");
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department;
    }
    public async Task<Department> UpdateDepartmentAsync(Department department)
    {
        if(department is null) throw new ArgumentNullException(nameof(department));

        var existingDepartment = await GetDepartmentByIdAsync(department.Id);
        if (existingDepartment == null) throw new KeyNotFoundException($"Department with ID {department.Id} not found.");
        existingDepartment.Name = department.Name;
        existingDepartment.Description = department.Description;
        existingDepartment.Location = department.Location;
        existingDepartment.Limit = department.Limit;
        var duplicateDepartment = await _context.Departments
            .FirstOrDefaultAsync(d => d.Id != department.Id && d.Name.ToLower() == department.Name.ToLower());
        if (duplicateDepartment != null) throw new InvalidOperationException($"Another department with name '{department.Name}' already exists.");
        _context.Departments.Update(existingDepartment);
        await _context.SaveChangesAsync();
        return existingDepartment;
    }
    public async Task DeleteDepartmentAsync(int id)
    {
        var department = await GetDepartmentByIdAsync(id);
        if (department == null) throw new KeyNotFoundException($"Department with ID {id} not found.");
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
    }
}