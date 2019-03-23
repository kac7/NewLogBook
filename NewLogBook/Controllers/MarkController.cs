using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLogBook.Models;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook.Controllers
{
    public class MarkController : Controller
    {
        private IMarkRepository markRepository;
        private IStudentRepository studentRepository;
        private ITeacherRepository teacherRepository;
        private ITeacherSubjectRepository teacherSubject;

        public MarkController(IMarkRepository markRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository, ITeacherSubjectRepository teacherSubject)
        {
            this.markRepository = markRepository;
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.teacherSubject = teacherSubject;
        }
        [HttpGet]
        public async Task<IActionResult> AddMark(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            MarkModel model = await markRepository.GetAddMark(id, studentRepository, teacherRepository, teacherSubject);
            if (model == null)
            {
                return View("WarningMark");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMark([Bind("StudentId, SubjectId, Value")] MarkModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await markRepository.GetAddMarkPost(model, teacherSubject))
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Student");
            }
            return View(model);
        }
    }
}