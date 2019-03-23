using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewLogBook.Entities;
using NewLogBook.Models.interfaces;

namespace NewLogBook.Models
{
    public class TeacherModel : ICloneable, IDropDownList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter First name!")]
        [Display(Name = "First name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last name!")]
        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Choose a department!")]
        [Display(Name = "Choose department")]
        public string DepartmentId { get; set; }
        
        public Department Department { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }
        public List<Department> Departments { get; set; }
        public object Clone()
        {
            if (Departments.Count == 0)
            {
                return null;
            }
            return this.MemberwiseClone();
        }

        public SelectList GetSelectList()
        {
            return new SelectList(Departments, "Id", "Name");
        }

        public List<SelectListItem> GetListItemSelected()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Department VARIABLE in Departments)
            {
                if (Department.Id.Equals(VARIABLE.Id))
                {
                    items.Add(new SelectListItem { Text = VARIABLE.Name, Value = $"{VARIABLE.Id}", Selected = true });
                }
                else
                {
                    items.Add(new SelectListItem { Text = VARIABLE.Name, Value = $"{VARIABLE.Id}", Selected = false });
                }

            }

            return items;
        }
    }
}
