using System.Collections.Generic;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Interfaces.Repositories;

namespace Timetable.Web.Api.Repository.Interfaces
{
    public interface ITimeslotRepository : IRepository<Timeslot>
    {
        IList<Timeslot> GetTimeslotsForStudentId(long studentId);
        bool Add(Timeslot item);
        bool DeleteByStudentId(long studentId);
        bool Update(long id, Timeslot item);
    }
}
