using Shared.Data;
using Shared.Repositories;
using StudyPrograms.Entities;

namespace StudyPrograms.Repositories;

public class StudyProgramRepository : Repository<StudyProgram>, IStudyProgramRepository
{
    private readonly StudentAffairsDbContext _context;

    public StudyProgramRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}