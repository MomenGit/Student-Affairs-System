using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAffairsSystem.CommonModels.Entities;

public class Admin : BaseEntity
{
    [ForeignKey("User")] public Guid UserId { get; set; }

    public List<AdminPrivileges>? Privileges { get; set; }
}

public enum AdminPrivileges
{
    Super = 1
}