namespace StudentAffairsSystem.CommonModels.Entities;

public class BaseEntity
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; }
}