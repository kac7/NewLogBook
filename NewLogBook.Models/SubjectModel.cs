using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewLogBook.Entities;
using NewLogBook.Models.interfaces;

namespace NewLogBook.Models
{
    public class SubjectModel : ICloneable, IDropDownList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name!")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Choose Teacher!")]
        [Display(Name = "Teacher")]
        public string TeacherId { get; set; }
        public List<TeacherSubject> TeachersSubjects { get; set; }
        public List<Teacher> Teachers { get; set; }
        public object Clone()
        {
            if (Teachers.Count == 0)
            {
                return null;
            }

            return this.MemberwiseClone();
        }

        public SelectList GetSelectList()
        {
            return new SelectList(Teachers, "Id", "LastName");
        }

        public List<SelectListItem> GetListItemSelected()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var VARIABLE in TeachersSubjects)
            {
                if (Id.Equals(VARIABLE.SubjectId))
                {
                    TeacherId = $"{VARIABLE.TeacherId}";
                }
            }

            foreach (var VARIABLE in Teachers)
            {
                if (Int32.Parse(TeacherId).Equals(VARIABLE.Id))
                {
                    items.Add(new SelectListItem { Text = $"{VARIABLE.FirstName} {VARIABLE.LastName}", Value = $"{VARIABLE.Id}", Selected = true});
                }
                else
                {
                    items.Add(new SelectListItem { Text = $"{VARIABLE.FirstName} {VARIABLE.LastName}", Value = $"{VARIABLE.Id}", Selected = false});
                }
            }

            return items;
        }

        public List<SelectListItem> GetListSelectTeacher()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var VARIABLE in Teachers)
            {
                items.Add(new SelectListItem { Text = $"{VARIABLE.FirstName} {VARIABLE.LastName}", Value = $"{VARIABLE.Id}" });
            }

            return items;
        }
    }
}
