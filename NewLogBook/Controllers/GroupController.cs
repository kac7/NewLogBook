using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewLogBook.Models;
using NewLogBook.Repositories.interfaces;
using Group = NewLogBook.Entities.Group;

namespace NewLogBook.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupRepository groupRepository;
        private readonly IFacultieRepository facultyRepository;
        public GroupController(IGroupRepository groupRepository, IFacultieRepository facultyRepository)
        {
            this.groupRepository = groupRepository;
            this.facultyRepository = facultyRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await groupRepository.ShowListGroups());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            GroupModel groupModel = await groupRepository.GetCreateGroup(facultyRepository);
            if (groupModel == null)
            {
                return View("WarningGroup");

            }
            return View(groupModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, FacultyId")] GroupModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await groupRepository.CreateGroupPost(model))
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
            GroupModel model = await groupRepository.GetEditGroup(facultyRepository, id);
            if (model == null)
            {
                return View("WarningGroup");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name, FacultyId")] GroupModel model)
        {
            if (ModelState.IsValid)
            {
                if (!await groupRepository.EditGroupPost(model))
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            Group group = await groupRepository.DetailsGroup(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!await groupRepository.DeleteGroup(id))
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}