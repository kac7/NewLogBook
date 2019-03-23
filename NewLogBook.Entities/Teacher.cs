using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NewLogBook.Abstracrions;

namespace NewLogBook.Entities
{
    [Table("teachers")]
    public class Teacher : DbEntity
    {
        [Column("firstName")]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Column("lastName")]
        [StringLength(64)]
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartamentId")]
        public virtual Department Department { get; set; }
        public virtual List<TeacherSubject> TeacherSubjects { get; set; }
    }
}
