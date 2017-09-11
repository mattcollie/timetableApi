using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Services;
using Timetable.Web.Api.Repository.Interfaces;
using Timetable.Web.Api.Service.Interfaces;

namespace Timetable.Web.Api.Service.Services
{
    public class TimeslotService : Service<Timeslot>, ITimeslotService
    {
        protected ITimeslotRepository TimeslotRepository { get; set; }

        public TimeslotService(ITimeslotRepository repository) : base(repository)
        {
            TimeslotRepository = repository;
        }

        public bool Add(Timeslot item)
        {
            return TimeslotRepository.Add(item);
        }
    }
}
