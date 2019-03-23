using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewLogBook.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name!")]
        [Display(Name = "Name:")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
