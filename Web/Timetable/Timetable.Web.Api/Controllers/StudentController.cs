using System.Linq;
using System.Net;
using System.Web.Mvc;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Repository.Interfaces;

namespace Timetable.Web.Api.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : System.Web.Http.ApiController
    {
        protected IStudentRepository StudentRepository { get; set; }
        protected ITimeslotRepository TimeslotRepository { get; set; }

        public StudentController(IStudentRepository studentRepository, ITimeslotRepository timeslotRepository)
        {
            StudentRepository = studentRepository;
            TimeslotRepository = timeslotRepository;
        }

        [HttpGet]
        public IQueryable<Student> Get()
        {
            return StudentRepository.All();
        }

        [HttpGet]
        [Route("{studentId}")]
        public Student Get(long studentId)
        {
            return StudentRepository.GetById(studentId);
        }

        [HttpPut]
        [Route("{student}")]
        public ActionResult Put(Student student)
        {
            if (StudentRepository.GetById(student.StudentId) != null) return new HttpStatusCodeResult(HttpStatusCode.Gone);
            return new HttpStatusCodeResult(StudentRepository.Add(student) ? HttpStatusCode.Created : HttpStatusCode.Gone);
        }
        
        [HttpPost]
        [Route("{student}")]
        public ActionResult Post(Student student)
        {
            if (StudentRepository.GetById(student.StudentId) == null) return new HttpStatusCodeResult(HttpStatusCode.Gone);
            return new HttpStatusCodeResult(StudentRepository.Update(student.StudentId, student) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(long id)
        {
            if (StudentRepository.GetById(id) == null) return new HttpStatusCodeResult(HttpStatusCode.Gone);
            if (TimeslotRepository.DeleteByStudentId(id))
                return new HttpStatusCodeResult(StudentRepository.Delete(id) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
            return new HttpStatusCodeResult(HttpStatusCode.Gone);
        }
    }
}
