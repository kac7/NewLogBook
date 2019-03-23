using System;
using System.Collections.Generic;
using System.Text;
using NewLogBook.Entities;

namespace NewLogBook.Models.Ratings
{
     class SortedStudents : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            double x_sum = 0;
            double y_sum = 0;
            if (x.Marks.Count != 0)
            {
                foreach (var VARIABLE in x.Marks)
                {
                    x_sum += VARIABLE.Value;
                }

                x_sum = x_sum / x.Marks.Count;
            }

            if (y.Marks.Count != 0)
            {
                foreach (var VARIABLE in y.Marks)
                {
                    y_sum += VARIABLE.Value;
                }

                y_sum = y_sum / y.Marks.Count;
            }
            
            int otv = x_sum.CompareTo(y_sum);
            if (otv != 0)
            {
                return -otv;
            }
            else
            {
                string x_Name = String.Format("{0} {1}", x.LastName, x.FirstName);
                string y_Name = String.Format("{0} {1}", y.LastName, y.FirstName);

                return x_Name.CompareTo(y_Name);
            }
        }
    }
}
