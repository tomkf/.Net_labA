using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabA.Models
{
    public class InterviewRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public virtual Company Company { get; set; }
    }
}
