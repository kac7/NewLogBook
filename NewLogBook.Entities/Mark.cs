using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NewLogBook.Abstracrions;

namespace NewLogBook.Entities
{
    [Table("marks")]
    public class Mark : DbEntity
    {
        public int TeacherSubjectId { get; set; }
        [ForeignKey("TeacherSubjectId")]
        public virtual TeacherSubject TeacherSubject { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [Column("value")]
        public int Value { get; set; }
    }
}
