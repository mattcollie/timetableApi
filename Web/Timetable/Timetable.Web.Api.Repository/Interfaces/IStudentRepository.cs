using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Interfaces.Repositories;

namespace Timetable.Web.Api.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentByStudentId(long studentId);
        bool Add(Student item);
        bool Update(long id, Student item);
    }
}
