using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Repository.Interfaces;

namespace Timetable.Web.Api.Controllers
{
    [RoutePrefix("api/timeslot")]
    public class TimeslotController : ApiController
    {
        protected IStudentRepository StudentRepository { get; set; }
        protected ITimeslotRepository TimeslotRepository { get; set; }

        public TimeslotController(IStudentRepository studentRepository, ITimeslotRepository timeslotRepository)
        {
            StudentRepository = studentRepository;
            TimeslotRepository = timeslotRepository;
        }

        [HttpGet]
        public IQueryable<Timeslot> Index()
        {
            return TimeslotRepository.All();
        }

        [HttpGet]
        [Route("get/{timeslotId}")]
        public Timeslot Get(long timeslotId)
        {
            return TimeslotRepository.GetById(timeslotId);
        }

        [HttpPut]
        [Route("add/{timeslots}")]
        public bool Add(IList<Timeslot> timeslots)
        {
            return timeslots.All(t => TimeslotRepository.Add(t));
        }

        [HttpPut]
        [Route("add/{day}/{hour}/{duration}/{studentId}/{className}/{paperName}/{classType?}")]
        public bool Add(int day, int hour, int duration, long studentId, string className, string paperName, string classType = "tutorial")
        {
            return TimeslotRepository.Add(new Timeslot { Day = day, Hour = hour, DurationMinutes = duration, StudentId = studentId, ClassName = className, PaperName = paperName, ClassType = classType });
        }
        
        [HttpPut]
        [Route("update/{timeslotId}/{day}/{hour}/{duration}/{studentId}/{className}/{paperName}/{classType}")]
        public bool Update(long timeslotId, int day, int hour, int duration, long studentId, string className, string paperName, string classType)
        {
            if (TimeslotRepository.GetById(timeslotId) == null) return false;
            return TimeslotRepository.Update(timeslotId, new Timeslot { Day = day, Hour = hour, DurationMinutes = duration, StudentId = studentId, ClassName = className, PaperName = paperName, ClassType = classType });
        }

        [HttpDelete]
        [Route("delete/{timeslotId}")]
        public bool Delete(long timeslotId)
        {
            return TimeslotRepository.Delete(timeslotId);
        }
    }
}
