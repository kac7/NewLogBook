using NewLogBook.Abstracrions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewLogBook.Entities
{
    [Table("faculties")]
    public class Facultie : DbEntity
    {
        [Column("name")]
        [StringLength(64)]
        public string Name { get; set; }
        public virtual List<Group> Groups { get; set; }
    }
}
