using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLogBook.Entities;
using NewLogBook.Models;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook.Controllers
{
    public class SubjectController : Controller
    {
        private ISubjectRepository subjectRepository;
        private ITeacherRepository teacherRepository;
        private ITeacherSubjectRepository teacherSubject;

        public SubjectController(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository,
            ITeacherSubjectRepository teacherSubject)
        {
            this.subjectRepository = subjectRepository;
            this.teacherRepository = teacherRepository;
            this.teacherSubject = teacherSubject;
        }
        public async Task<IActionResult> Index()
        {
            return View(await subjectRepository.GetListSubject());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SubjectModel model = await subjectRepository.CreateSubject(teacherRepository);
            if (model == null)
            {
                return View("WarningSubject");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, TeacherId")] SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await subjectRepository.CreateSubjectPost(teacherSubject, model))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            SubjectModel model = await subjectRepository.EditSabject(id, teacherRepository);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name, TeacherId")] SubjectModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await subjectRepository.isEditSubjectPost(model, teacherSubject))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Subject subject = await subjectRepository.DetailsSubject(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!await subjectRepository.IsDeleteSubject(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}