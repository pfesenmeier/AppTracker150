using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
    public class StudentFullDetail
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CohortListItem Cohort { get; set; }
        public string ResumeLink { get; set; }
        public string LinkedInLink { get; set; }
        public string PortfolioLink { get; set; }
        public string GitHub { get; set; }
        //says "FullTime" or "PartTime"
        public string FullOrPartTime { get; set; }

        public List<ApplicationListItem> Applications { get; set; }
    }
}
