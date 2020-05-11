using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabA.ViewModel
{
    public class InterviewRequestVM
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }

    }
}
