using System.Linq;
using System.Web.Http;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Repository.Interfaces;

namespace Timetable.Web.Api.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        protected IStudentRepository StudentRepository { get; set; }
        protected ITimeslotRepository TimeslotRepository { get; set; }

        public StudentController(IStudentRepository studentRepository, ITimeslotRepository timeslotRepository)
        {
            StudentRepository = studentRepository;
            TimeslotRepository = timeslotRepository;
        }

        [HttpGet]
        public IQueryable<Student> Index()
        {
            return StudentRepository.All();
        }

        [HttpGet]
        [Route("get/{studentId}")]
        public Student Get(long studentId)
        {
            return StudentRepository.GetById(studentId);
        }

        [HttpPut]
        [Route("add/{studentId}/{firstName}/{lastName}")]
        public bool Add(long studentId, string firstName, string lastName)
        {
            if (StudentRepository.GetById(studentId) != null) return false;
            return StudentRepository.Add(new Student { StudentId = studentId, FirstName = firstName, LastName = lastName });
        }
        
        [HttpPut]
        [Route("update/{studentId}/{firstName}/{lastName}")]
        public bool Update(long studentId, string firstName, string lastName)
        {
            if (StudentRepository.GetById(studentId) == null) return false;
            return StudentRepository.Update(studentId, new Student { FirstName = firstName, LastName = lastName });
        }

        [HttpDelete]
        [Route("delete/{studentId}")]
        public bool Delete(long studentId)
        {
            if(TimeslotRepository.DeleteByStudentId(studentId))
                return StudentRepository.Delete(studentId);
            return false;
        }
    }
}
