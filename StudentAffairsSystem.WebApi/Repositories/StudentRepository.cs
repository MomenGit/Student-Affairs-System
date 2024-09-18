using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface IStudentRepository : IRepository<Student>
{
}

public class StudentRepository : Repository<Student>, IStudentRepository
{
    private readonly StudentAffairsDbContext _context;

    public StudentRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}