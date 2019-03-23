using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NewLogBook.Abstracrions;

namespace NewLogBook.Entities
{
    [Table("teachers_subjects")]
    public class TeacherSubject : DbEntity
    {
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public virtual List<Mark> Marks { get; set; }
    }
}
