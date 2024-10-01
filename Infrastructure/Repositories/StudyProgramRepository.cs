using Infrastructure.Data;
using Shared.Repositories;
using StudyProgramCourses.Entities;
using StudyProgramCourses.Repositories;

namespace Infrastructure.Repositories;

public class StudyProgramCourseRepository : Repository<StudyProgramCourse>, IStudyProgramCourseRepository
{
    private readonly StudentAffairsDbContext _context;

    public StudyProgramCourseRepository(StudentAffairsDbContext context) : base(context)
    {
        _context = context;
    }
}