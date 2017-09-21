using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [System.Web.Mvc.HttpGet]
        public IQueryable<Timeslot> Get()
        {
            return TimeslotRepository.All();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("{id}")]
        public IList<Timeslot> Get(long id)
        {
            return TimeslotRepository.GetTimeslotsForStudentId(id);
        }
        
        [System.Web.Mvc.HttpPut]
        [System.Web.Mvc.Route("{timeslots}")]
        public System.Web.Mvc.ActionResult Put(IList<Timeslot> timeslots)
        {
            return new System.Web.Mvc.HttpStatusCodeResult(timeslots.All(t => TimeslotRepository.Add(t)) ? HttpStatusCode.Created : HttpStatusCode.Gone);
        }

        [System.Web.Mvc.HttpPut]
        [System.Web.Mvc.Route("{timeslot}")]
        public System.Web.Mvc.ActionResult Put(Timeslot timeslot)
        {
            return new System.Web.Mvc.HttpStatusCodeResult(TimeslotRepository.Add(timeslot) ? HttpStatusCode.Created : HttpStatusCode.Gone);
        }
        
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("{timeslot}")]
        public System.Web.Mvc.ActionResult Update(Timeslot timeslot)
        {
            if (TimeslotRepository.GetById(timeslot.Id) == null) return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Gone);
            return new System.Web.Mvc.HttpStatusCodeResult(TimeslotRepository.Update(timeslot.Id, timeslot) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
        }

        [System.Web.Mvc.HttpDelete]
        [System.Web.Mvc.Route("{id}")]
        public System.Web.Mvc.ActionResult Delete(long id)
        {
            if (TimeslotRepository.GetById(id) == null) return new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Gone);
            return new System.Web.Mvc.HttpStatusCodeResult(TimeslotRepository.Delete(id) ? HttpStatusCode.NoContent : HttpStatusCode.Gone);
        }
    }
}
