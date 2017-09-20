using System;
using System.Linq;
using Timetable.Data.Access.Context;
using Timetable.Data.Objects.Tables;
using Timetable.Web.Api.Common.Repositories;
using Timetable.Web.Api.Repository.Interfaces;

namespace Timetable.Web.Api.Repository.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(TimetableContext context) : base(context)
        {
            
        }

        public Student GetStudentByBarcodeId(long barcodeId)
        {
            return Context.Students.FirstOrDefault(n => n.BarcodeId == barcodeId);
        }

        public Student GetStudentByStudentId(long studentId)
        {
            return Context.Students.FirstOrDefault(n => n.StudentId == studentId);
        }

        public bool Update(long id, Student item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            Student entity = GetById(id);
            if (entity == null)
                return false;

            Context.Entry(entity).CurrentValues.SetValues(item);

            return SaveChanges() > 0;
        }
    }
}
