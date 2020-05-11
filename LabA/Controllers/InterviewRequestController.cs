using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LabA.Repositories;
using LabA.ViewModel;
using LabA.Models;

namespace LabA.Controllers
{
    public class InterviewRequestController : Controller
    {
        private PortfolioContext db;

        // Initialize context when controller is created.
        public InterviewRequestController(PortfolioContext db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            InterviewRequestVMRepo irRepo = new InterviewRequestVMRepo(db);
            IEnumerable<InterviewRequestVM> ir = irRepo.GetAll();
            return View(ir);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(InterviewRequestVM irVM)
        {
            InterviewRequestVMRepo irRepo = new InterviewRequestVMRepo(db);
            irRepo.Create(irVM);

            // go to index action method of the same controller.
            return RedirectToAction("Index", "ProjectTechnologies");
        }
    }
}