using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NewLogBook.Abstracrions;

namespace NewLogBook.Entities
{
    [Table("departaments")]
    public class Department : DbEntity
    {
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
    }
}
