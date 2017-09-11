using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Timetable.Common.BaseEntities;

namespace Timetable.Data.Objects.Tables
{
    [Table("Timeslots")]
    public class Timeslot : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int Day { get; set; }

        public int Hour { get; set; }

        public int DurationMinutes { get; set; }

        public string ClassName { get; set; }

        public string PaperName { get; set; }

        public string ClassType { get; set; }

        public long StudentId { get; set; }
        
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

    }
}
