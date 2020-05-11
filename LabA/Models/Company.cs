using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabA.Models
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        //  public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<InterviewRequest> InterviewRequests { get; set; }

    }
}
