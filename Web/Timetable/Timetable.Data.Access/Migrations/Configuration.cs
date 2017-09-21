using System.Linq;
using System.Data.Entity.Migrations;
using Timetable.Data.Access.Context;
using Timetable.Data.Objects.Tables;

namespace Timetable.Data.Access.Migrations
{
    public class Configuration : DbMigrationsConfiguration<TimetableContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private TimetableContext Context { get; set; }

        protected override void Seed(TimetableContext context)
        {
            Context = context;
            SeedStudents();
            SeedTimeslots();
            Context.SaveChanges();
        }

        #region Seeds

        private void SeedStudents()
        {
            if (Context.Students.Any(s => s.StudentId == 10001876)) return;
            Context.Students.Add(new Student { StudentId = 10001876, FirstName = "Matt", LastName = "Collecutt" });
        }

        private void SeedTimeslots()
        {
            if (Context.Timeslots.Count() > 4) return;
            Context.Timeslots.Add(new Timeslot { Day = 0, Hour = 15, DurationMinutes = 120, StudentId = 10001876, PaperName = "BMGT6003", ClassName = "DT207", ClassType = "Lecture" });
            Context.Timeslots.Add(new Timeslot { Day = 1, Hour = 8, DurationMinutes = 120, StudentId = 10001876, PaperName = "BMGT6003", ClassName = "DT303", ClassType = "Tutorial" });
            Context.Timeslots.Add(new Timeslot { Day = 1, Hour = 15, DurationMinutes = 60, StudentId = 10001876, PaperName = "BMGT6003", ClassName = "DT303", ClassType = "Tutorial" });
            Context.Timeslots.Add(new Timeslot { Day = 2, Hour = 8, DurationMinutes = 120, StudentId = 10001876, PaperName = "COMP6001", ClassName = "DT303", ClassType = "Tutorial" });
            Context.Timeslots.Add(new Timeslot { Day = 3, Hour = 10, DurationMinutes = 120, StudentId = 10001876, PaperName = "COMP6001", ClassName = "DT303", ClassType = "Tutorial" });
        }

        #endregion
    }
}
