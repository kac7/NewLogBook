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
    public class FacultieController : Controller
    {
        private readonly IFacultieRepository facultieRepository;
         public FacultieController(IFacultieRepository facultieRepository)
         {
             this.facultieRepository = facultieRepository;
         }
        public async Task<IActionResult> Index()
        {
            return View(await facultieRepository.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")]FacultieModel faculty)
        {
            if (ModelState.IsValid)
            {
               await facultieRepository.CreateFacultie(faculty);
               return RedirectToAction(nameof(Index));
            }

            return View(faculty);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            FacultieModel facultieModel = await facultieRepository.FindFacultie(id);
            if (facultieModel == null)
            {
                return NotFound();
            }

            return View(facultieModel);
        }

        public async Task<IActionResult> Edit([Bind("Name,id")] FacultieModel facultie)
        {
            if (ModelState.IsValid)
            {
                if (!await facultieRepository.EditFacultie(facultie))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(facultie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!await facultieRepository.DeleteFacultie(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            Facultie facultie = await facultieRepository.DetailsFacultie(id);
            if (facultie == null)
            {
                return NotFound();
            }

            return View(facultie);
        }
    }
}