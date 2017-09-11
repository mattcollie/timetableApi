using System.Data.Entity.Migrations;
using Timetable.Data.Access.Context;

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

            Context.SaveChanges();
        }

        #region Seeds

        

        #endregion
    }
}
