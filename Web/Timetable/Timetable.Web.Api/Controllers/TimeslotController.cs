using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Repository.Interfaces;

namespace Timetable.Web.Api.Controllers
{
    [RoutePrefix("api/timeslot")]
    public class TimeslotController : System.Web.Http.ApiController
    {
        protected IStudentRepository StudentRepository { get; set; }
        protected ITimeslotRepository TimeslotRepository { get; set; }

        public TimeslotController(IStudentRepository studentRepository, ITimeslotRepository timeslotRepository)
        {
            StudentRepository = studentRepository;
            TimeslotRepository = timeslotRepository;
        }

        [HttpGet]
        public IQueryable<Timeslot> Get()
        {
            return TimeslotRepository.All();
        }

        [HttpGet]
        [Route("{id}")]
        public IList<Timeslot> Get(long id)
        {
            return TimeslotRepository.GetTimeslotsForStudentId(id);
        }
        
        [HttpPut]
        [Route("{timeslots}")]
        public ActionResult Put(IList<Timeslot> timeslots)
        {
            return new HttpStatusCodeResult(timeslots.All(t => TimeslotRepository.Add(t)) ? HttpStatusCode.Created : HttpStatusCode.Gone);
        }

        [HttpPut]
        [Route("{timeslot}")]
        public ActionResult Put(Timeslot timeslot)
        {
            return new HttpStatusCodeResult(TimeslotRepository.Add(timeslot) ? HttpStatusCode.Created : HttpStatusCode.Gone);
        }
        
        [HttpPost]
        [Route("{timeslot}")]
        public ActionResult Update(Timeslot timeslot)
        {
            if (TimeslotRepository.GetById(timeslot.Id) == null) return new HttpStatusCodeResult(HttpStatusCode.Gone);
            return new HttpStatusCodeResult(TimeslotRepository.Update(timeslot.Id, timeslot) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(long id)
        {
            if (TimeslotRepository.GetById(id) == null) return new HttpStatusCodeResult(HttpStatusCode.Gone);
            return new HttpStatusCodeResult(TimeslotRepository.Delete(id) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
        }
    }
}
