using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Timetable.Common.BaseEntities;

namespace Timetable.Data.Objects.Tables
{
    [Table("Students")]
    public class Student : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long? BarcodeId { get; set; }

        public ICollection<Timeslot> Timeslots { get; set; }
    }
}
