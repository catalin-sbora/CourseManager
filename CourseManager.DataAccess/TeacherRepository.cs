using CourseManager.ApplicationLogic.Abstractions;
using CourseManager.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseManager.DataAccess
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(CourseManagerDbContext dbContext):base(dbContext)
        {
            
        }
        public Teacher GetTeacherByUserId(Guid userId)
        {
            return dbContext.Teachers
                            .Where(teacher => teacher.UserId == userId)
                            .SingleOrDefault();
        }
    }
}
