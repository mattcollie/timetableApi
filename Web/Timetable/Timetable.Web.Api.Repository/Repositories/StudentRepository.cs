using System.Linq;
using Timetable.Data.Access.Context;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Repositories;
using Timetable.Web.Api.Repository.Interfaces;

namespace Timetable.Web.Api.Repository.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(TimetableContext context) : base(context)
        {

        }

        public Student GetStudentByStudentId(long studentId)
        {
            return Context.Students.FirstOrDefault(n => n.StudentId == studentId);
        }
    }
}
