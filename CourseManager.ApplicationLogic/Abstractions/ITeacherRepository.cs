using CourseManager.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.Abstractions
{
    public interface ITeacherRepository:IRepository<Teacher>
    {
        Teacher GetTeacherByUserId(Guid userId);
    }
}
