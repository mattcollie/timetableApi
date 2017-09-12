using System.Linq;
using System.Web.Http;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Repository.Interfaces;


namespace Timetable.Web.Api.Controllers
{
    [RoutePrefix("api/player")]
    public class StudentController : ApiController
    {
        protected IStudentRepository StudentRepository { get; set; }

        public StudentController(IStudentRepository repository)
        {
            StudentRepository = repository;
        }

        [HttpGet]
        public IQueryable<Student> Index()
        {
            return StudentRepository.All();
        }

        [HttpGet]
        [Route("GetStudent/{studentId}")]
        public Student GetStudent(long studentId)
        {
            return StudentRepository.GetById(studentId);
        }
    }
}
