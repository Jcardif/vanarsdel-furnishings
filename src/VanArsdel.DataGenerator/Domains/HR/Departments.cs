namespace VanArsdel.DataGenerator.Domains.HR;

public class Departments
{
    public Guid DepartmentId { get; init; }
    public string DepartmentName { get; init; } = default!;
    public Guid ManagerId { get; init; }
}