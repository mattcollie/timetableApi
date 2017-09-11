using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Services;
using Timetable.Web.Api.Repository.Interfaces;
using Timetable.Web.Api.Service.Interfaces;

namespace Timetable.Web.Api.Service.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        protected IStudentRepository StudentRepository { get; set; }

        public StudentService(IStudentRepository repository) : base(repository)
        {
            StudentRepository = repository;
        }

        public bool Add(Student item)
        {
            return StudentRepository.Add(item);
        }
    }
}
