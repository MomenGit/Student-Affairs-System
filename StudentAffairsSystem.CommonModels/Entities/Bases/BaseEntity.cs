namespace StudentAffairsSystem.CommonModels.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; }
    public DateTime CreationDate { get; init; }

    public DateTime ModificationDate { get; set; }
}