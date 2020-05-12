using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabA.Models;
using LabA.Repositories;
using LabA.ViewModel;

namespace LabA.Controllers
{
    //[Route("tomferris")]
    public class ProjectTechnologiesController : Controller
    {
        private PortfolioContext db;

        private readonly PortfolioContext _context;
        public ProjectTechnologiesController(PortfolioContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string sortOrder, string searchString, int? page)
        {
            string sort = String.IsNullOrEmpty(sortOrder) ? "title_asc" : sortOrder;
            string search = String.IsNullOrEmpty(searchString) ? "" : searchString;

            ViewData["CurrentSort"] = sort;
            ViewData["CurrentFilter"] = search;

            var projectTechnologies = new TechnologyProjectVMRepo(db).GetAll(sort, search);

            int pageSize = 3;

            return View(PaginatedList<TechnologyProjectVM>.Create(projectTechnologies
                       , page ?? 1, pageSize));
        }


        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            TechnologyProjectVMRepo repo = new TechnologyProjectVMRepo(db);
            return View(repo.GetDetails(id));
        }
    }
}