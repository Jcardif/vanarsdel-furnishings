namespace VanArsdel.DataGenerator.Domains.HR;

public class Employee
{
    public Guid EmployeeId { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string PhoneNumber { get; init; } = default!;
    public string JobTitle { get; init; } = default!;
    public Guid DepartmentId { get; init; }
}