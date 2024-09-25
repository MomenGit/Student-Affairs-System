using StudentAffairsSystem.Shared.Entities;

namespace StudentAffairsSystem.Domain.Users.Entities;

public class UserSubType : BaseEntity
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
}