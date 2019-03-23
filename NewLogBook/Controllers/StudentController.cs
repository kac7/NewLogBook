using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLogBook.Entities;
using NewLogBook.Models;
using NewLogBook.Models.Ratings;
using NewLogBook.Repositories.interfaces;

namespace NewLogBook.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;
        private IGroupRepository groupRepository;
        private RatingStudents rating;
        public StudentController(IStudentRepository studentRepository, IGroupRepository groupRepository, RatingStudents rating)
        {
            this.studentRepository = studentRepository;
            this.groupRepository = groupRepository;
            this.rating = rating;
        }
        public async Task<IActionResult> Index()
        {
            return View(await rating.GetSortStudent());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            StudentModel model = await studentRepository.CreateStudent(groupRepository);
            if (model == null)
            {
                return View("WarningStudent");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, GroupId")] StudentModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await studentRepository.CreateStudentPost(model))
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
            StudentModel model = await studentRepository.GetEditStudent(groupRepository, id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, FirstName, LastName, GroupId")] StudentModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await studentRepository.EditStudentPost(model))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Student student = await studentRepository.DetailsStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!await studentRepository.IsDeleteStudent(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}