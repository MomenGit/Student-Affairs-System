namespace StudentAffairsSystem.Shared.Entities;

public abstract class BaseEntity : BaseDateTrace
{
    public Guid Id { get; set; }
}