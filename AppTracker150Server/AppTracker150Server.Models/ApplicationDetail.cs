using AppTracker150Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
    public class ApplicationDetail
    {
        public int ApplicationId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string CompanyName { get; set; }
        public string PositionName { get; set; }
        public string JobLink { get; set; }
        public string JobLocation { get; set; }
        public string Research { get; set; }
        public string Contacts { get; set; }
        public string SourceOfPosting { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset DateCreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? DateModifiedUtc { get; set; }
    }
}
