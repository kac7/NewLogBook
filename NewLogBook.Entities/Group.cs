using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NewLogBook.Abstracrions;

namespace NewLogBook.Entities
{
    [Table("groups")]
    public class Group :DbEntity
    {
        [Column("name")]
        [StringLength(64)]
        public string Name { get; set; }
        public int FacultieId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual Facultie Facultie { get; set; }
        public List<Student> Students { get; set; }
    }
}
