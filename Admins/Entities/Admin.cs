using Users.Entities;

namespace Admins.Entities;

public class Admin : UserSubType
{
    public List<AdminPrivileges>? Privileges { get; set; }
}

public enum AdminPrivileges
{
    Super,
    Create,
    Read,
    Update,
    Delete
}