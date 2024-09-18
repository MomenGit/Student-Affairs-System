using StudentAffairsSystem.CommonModels.Entities;
using StudentAffairsSystem.WebApi.Data;

namespace StudentAffairsSystem.WebApi.Repositories;

public interface IStudyProgramRepository : IRepository<StudyProgram>
{
}

public class StudyProgramRepository : Repository<StudyProgram>, IStudyProgramRepository
{
    private readonly StudentAffairsDbContext _context;

    public StudyProgramRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}