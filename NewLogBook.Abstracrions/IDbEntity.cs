using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace NewLogBook.Abstracrions
{
    public interface IDbEntity
    {
        [Key]
        int Id { get; set; }
    }
}
