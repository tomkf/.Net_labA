using LabA.Models;
using LabA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabA.Repositories
{
    public class TechnologyProjectVMRepo
    {
        private PortfolioContext db;

        private readonly PortfolioContext _context;
        public TechnologyProjectVMRepo(PortfolioContext db)
        {
            this.db = db;
        }

        public IEnumerable<TechnologyProjectVM> GetAll()
        {
            return db.Projects.Select(tp => new TechnologyProjectVM
            {
                Project = tp,
                Technologies = tp.TechnologyProjects.Select(t => t.Technology)
            });
        }

        public TechnologyProjectVM GetDetails(int id)
        {
            return GetAll().FirstOrDefault(tp => tp.Project.ProjectId == id);
        }

        public IQueryable<TechnologyProjectVM> GetAll(string sortOrder, string searchString)
        {
            IQueryable<TechnologyProjectVM> projectTechnologies;
            if (!String.IsNullOrEmpty(searchString))
            {
                projectTechnologies = db.Projects.Select(p => new TechnologyProjectVM
                {
                    Project = p,
                    Technologies = p.TechnologyProjects.Select(tp => tp.Technology)
                })
                    .Where(pt => pt.Project.Title.Contains(searchString)
                    || pt.Technologies.Any(t => t.Name.Contains(searchString)));
            }
            else
            {
                projectTechnologies = db.Projects.Select(p => new TechnologyProjectVM
                {
                    Project = p,
                    Technologies = p.TechnologyProjects.Select(tp => tp.Technology)
                });
            }



            switch (sortOrder)
            {
                case "description_asc":
                    projectTechnologies =
                        projectTechnologies.OrderBy(pt => pt.Project.Description);
                    break;
                case "title_desc":
                    projectTechnologies =
                        projectTechnologies.OrderByDescending(pt => pt.Project.Title);
                    break;
                case "description_desc":
                    projectTechnologies =
                  projectTechnologies.OrderByDescending(pt => pt.Project.Description);
                    break;
                default:
                    projectTechnologies =
                        projectTechnologies.OrderBy(pt => pt.Project.Title);
                    break;
            };
            return projectTechnologies;
        }

    }
}
