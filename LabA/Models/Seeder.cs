using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabA.Models
{
    public class Seeder
    {
        private PortfolioContext db;
        public Seeder(PortfolioContext db)
        {
            this.db = db;
            SeedData();
        }

        public void SeedData()
        {
            // Exit if data exists.
            if (db.Technologies.Count() != 0)
            {
                return;
            }

            //Create a collection of Objects to add to the database.
            Technology[] seedTechnologies = new Technology[]
            {
                new Technology { Name = "HTML" },
                new Technology { Name = "CSS" },
                new Technology { Name = "Javascript" },
                new Technology { Name = "SQL" },
                new Technology { Name = ".NET Core MVC" }
            };


            Project[] seedProjects = new Project[]
            {
                new Project{ Title = "Tom Ferris", Description = "An example MVC Web App"},
                new Project { Title = "Project A", Description = "A second project" },
                new Project { Title = "Project B", Description = "A third project" },
                new Project { Title = "Project 1", Description = "A fourth project" },
                new Project { Title = "Project 2", Description = "A fifth project" }
            };
            db.Projects.AddRange(seedProjects);
            db.SaveChanges();


            foreach (Project seedProject in seedProjects)
            {
                foreach (Technology seedTechnology in seedTechnologies)
                {
                    TechnologyProject tp = new TechnologyProject
                    {
                        Project = seedProject,
                        Technology = seedTechnology
                    };
                    db.TechnologyProjects.Add(tp);
                }
            }

            // Commit child table additions to the database.
            db.SaveChanges();
        }

    }
}
