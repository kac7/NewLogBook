using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewLogBook.Models.interfaces
{
     interface IDropDownList
     {
         SelectList GetSelectList();
         List<SelectListItem> GetListItemSelected();
     }
}
