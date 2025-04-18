namespace VanArsdel.DataGenerator.Domains.HR;

public class OpenPositions
{
    public Guid PositionId { get; init; }
    public string JobTitle { get; init; } = default!;
    public Guid DepartmentId { get; init; }
    public Guid ReportingManagerId { get; init; }
    public string Country { get; init; } = default!;
    public string Region { get; init; } = default!;
    public string City { get; init; } = default!;
    public DateTime OpenDate { get; init; }
    public DateTime CloseDate { get; init; }
}