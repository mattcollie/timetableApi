using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Timetable.Common.BaseEntities;
using Timetable.Data.Objects.Tables;

namespace Timetable.Data.Access.Context
{
    [DbConfigurationType(typeof(TimetableContextConfiguration)]
    public class TimetableContext : DbContext
    {
        public TimetableContext() : base("name=DefaultConnection")
        {

        }

        #region Overrides

        public static TimetableContext Create()
        {
            return new TimetableContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("Students");
        }

        public new virtual IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            foreach (var entity in ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {
                DateTime now = DateTime.UtcNow;
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }

        #endregion

        #region Entities
        
        public virtual IDbSet<Student> Students { get; set; }

        #endregion
    }
}
