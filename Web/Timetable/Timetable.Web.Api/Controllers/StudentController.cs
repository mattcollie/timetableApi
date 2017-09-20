using System.Linq;
using System.Net;
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

        [System.Web.Mvc.HttpGet]
        public IQueryable<Student> Get()
        {
            return StudentRepository.All();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("{studentId}")]
        public Student Get(long studentId)
        {
            return StudentRepository.GetById(studentId);
        }

        [HttpGet]
        [Route("barcode/{barcodeId}")]
        public Student GetBarcode(long barcodeId)
        {
            return StudentRepository.GetStudentByBarcodeId(barcodeId);
        }

        [System.Web.Mvc.HttpPut]
        [System.Web.Mvc.Route("{student}")]
        public System.Web.Mvc.ActionResult Put(Student student)
        {
            if (StudentRepository.GetById(student.StudentId) != null) return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Gone);
            return new System.Web.Mvc.HttpStatusCodeResult(StudentRepository.Add(student) ? HttpStatusCode.Created : HttpStatusCode.Gone);
        }
        
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("{student}")]
        public System.Web.Mvc.ActionResult Post(Student student)
        {
            if (StudentRepository.GetById(student.StudentId) == null) return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Gone);
            return new System.Web.Mvc.HttpStatusCodeResult(StudentRepository.Update(student.StudentId, student) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
        }

        [System.Web.Mvc.HttpDelete]
        [System.Web.Mvc.Route("{id}")]
        public System.Web.Mvc.ActionResult Delete(long id)
        {
            if (StudentRepository.GetById(id) == null) return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Gone);
            if (TimeslotRepository.DeleteByStudentId(id))
                return new System.Web.Mvc.HttpStatusCodeResult(StudentRepository.Delete(id) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
            return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Gone);
        }
    }
}
