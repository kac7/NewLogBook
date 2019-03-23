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
    public class DepartmentController : Controller
    {
        private IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository departamentRepository)
        {
            this.departmentRepository = departamentRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await departmentRepository.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await departmentRepository.CreateDepartamentPost(model))
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
            DepartmentModel departament = await departmentRepository.GetEditDepartment(id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name")] DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await departmentRepository.EditDepartmentPost(model))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Department departament = await departmentRepository.DetailsDepartment(id);
            if (departament == null)
            {
                return NotFound();
            }

            return View(departament);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!await departmentRepository.IsDeleteDepartment(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}