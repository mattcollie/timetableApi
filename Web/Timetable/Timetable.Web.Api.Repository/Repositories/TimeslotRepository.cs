using System;
using System.Collections.Generic;
using System.Linq;
using Timetable.Data.Access.Context;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Repositories;
using Timetable.Web.Api.Repository.Interfaces;

namespace Timetable.Web.Api.Repository.Repositories
{
    public class TimeslotRepository : Repository<Timeslot>, ITimeslotRepository
    {
        public TimeslotRepository(TimetableContext context) : base(context)
        {
        
        }

        public bool DeleteByStudentId(long studentId)
        {
            return GetTimeslotsForStudentId(studentId)?.All(t => Delete(t.Id)) ?? false;
        }

        public IList<Timeslot> GetTimeslotsForStudentId(long studentId)
        {
            return Context.Timeslots.Where(t => t.StudentId == studentId).ToList();
        }

        public bool Update(long id, Timeslot item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            Timeslot entity = GetById(id);
            if (entity == null)
                return false;

            Context.Entry(entity).CurrentValues.SetValues(item);

            return SaveChanges() > 0;
        }
    }
}
