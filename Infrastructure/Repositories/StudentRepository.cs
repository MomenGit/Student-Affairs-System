using Infrastructure.Data;
using Shared.Repositories;
using Students.Entities;
using Students.Repositories;

namespace Infrastructure.Repositories;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    private readonly StudentAffairsDbContext _context;

    public StudentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}