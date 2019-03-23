using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewLogBook.Entities;

namespace NewLogBook.Models
{
    public class MarkModel : ICloneable 
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Choose Value!")]
        [Display(Name = "Value")]
        public string Value { get; set; }
        [Required(ErrorMessage = "Choose Subject!")]
        [Display(Name = "Subject")]
        public string SubjectId { get; set; }
        public List<TeacherSubject> TeacherSubjects { get; set; }
        public List<SelectListItem> Values { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value = "1", Text = "1"},
            new SelectListItem{Value = "2", Text = "2"},
            new SelectListItem{Value = "3", Text = "3"},
            new SelectListItem{Value = "4", Text = "4"},
            new SelectListItem{Value = "5", Text = "5"},
            new SelectListItem{Value = "6", Text = "6"},
            new SelectListItem{Value = "7", Text = "7"},
            new SelectListItem{Value = "8", Text = "8"},
            new SelectListItem{Value = "9", Text = "9"},
            new SelectListItem{Value = "10", Text = "10"},
            new SelectListItem{Value = "11", Text = "11"},
            new SelectListItem{Value = "12", Text = "12"}
        };
        public Dictionary<Teacher, List<Subject>> Dictionary { get; set; }

        public object Clone()
        {
            if (TeacherSubjects.Count == 0)
            {
                return null;
            }

            return this.MemberwiseClone();
        }

        public List<SelectListItem> GetSelectListItem()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var VARIABLE in Dictionary)
            {
                var name = new SelectListGroup {Name = $"{VARIABLE.Key.FirstName} {VARIABLE.Key.LastName}:"};
                foreach (var VAR in VARIABLE.Value)
                {
                    items.Add(new SelectListItem{Value = $"{VAR.Id}", Text = VAR.Name, Group = name});
                }
            }

            return items;
        }
    }
}
