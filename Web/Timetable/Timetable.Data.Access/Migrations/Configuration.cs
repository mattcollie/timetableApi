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
            Context.SaveChanges();
        }

        #region Seeds

        private void SeedStudents()
        {
            Context.Students.Add(new Student { StudentId = 10001876, FirstName = "Matt", LastName = "Collecutt" });
        } 

        #endregion
    }
}
