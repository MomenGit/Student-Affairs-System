using StudentAffairsSystem.Domain.Users.Entities;
using StudentAffairsSystem.Domain.Users.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    private readonly StudentAffairsDbContext _context;

    public StudentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}