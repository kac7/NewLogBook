using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NewLogBook.Abstracrions;

namespace NewLogBook.Entities
{
    [Table("students")]
    public class Student : DbEntity
    {
        [Column("firstName")]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Column("lastName")]
        [StringLength(64)]
        public string LastName { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
