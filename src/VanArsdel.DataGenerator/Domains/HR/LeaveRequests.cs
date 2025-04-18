namespace VanArsdel.DataGenerator.Domains.HR;

public class LeaveRequests
{
    public Guid LeaveId { get; init; }
    public Guid EmployeeId { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public LeaveType LeaveType { get; init; } = default!;
    public LeaveStatus Status { get; init; } = default!;
}