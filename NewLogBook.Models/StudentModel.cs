using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewLogBook.Entities;
using NewLogBook.Models.interfaces;

namespace NewLogBook.Models
{
    public class StudentModel : ICloneable, IDropDownList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter First Name!")]
        [Display(Name = "First Name:")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name!")]
        [Display(Name = "Last Name:")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Select a group!")]
        [Display(Name = "Select a group:")]
        public string GroupId { get; set; }
        public Group Group { get; set; }
        public List<Group> Groups { get; set; }
        public object Clone()
        {
            if (Groups.Count == 0)
            {
                return null;
            }

            return new StudentModel
            {
                Id = this.Id, FirstName = this.FirstName, LastName = this.LastName, Group = this.Group,
                GroupId = this.GroupId, Groups = this.Groups
            };
        }

        public SelectList GetSelectList()
        {
            return new SelectList(Groups, "Id", "Name");
        }

        public List<SelectListItem> GetListItemSelected()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Group VARIABLE in Groups)
            {
                if (Group.Id.Equals(VARIABLE.Id))
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
