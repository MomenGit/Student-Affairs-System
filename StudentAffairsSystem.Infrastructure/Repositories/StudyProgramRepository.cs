using StudentAffairsSystem.Domain.AcademicStructure.Entities;
using StudentAffairsSystem.Domain.AcademicStructure.Repositories;
using StudentAffairsSystem.Infrastructure.Data;

namespace StudentAffairsSystem.Infrastructure.Repositories;

public class StudyProgramRepository : Repository<StudyProgram>, IStudyProgramRepository
{
    private readonly StudentAffairsDbContext _context;

    public StudyProgramRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}