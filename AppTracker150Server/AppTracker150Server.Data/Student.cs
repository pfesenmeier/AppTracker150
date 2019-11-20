using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Data
{
     public class Student
     {
        [Required]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CohortId { get; set; }

        public string ResumeLink { get; set; }

        public string LinkedInLink { get; set; }

        public string PortfolioLink { get; set; }

        public string GitHub { get; set; }

    }
}
