using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Interfaces.Services;

namespace Timetable.Web.Api.Service.Interfaces
{
    public interface IStudentService : IService<Student>
    {
        bool Add(Student item);
    }
}
