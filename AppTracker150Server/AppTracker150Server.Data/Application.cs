using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Data
{
    public enum ApplicationStatus { Hired, Rejected, Pending }
    public class Application
    {
        [Required]
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public DateTimeOffset DateCreatedUtc { get; set; }
        public DateTimeOffset? DateModifiedUtc { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public string CompanyName { get; set; }
        public string PositionName { get; set; }
        public string JobLink { get; set; }
        public string JobLocation { get; set; }
        public string Research { get; set; }
        public string Contacts { get; set; }
        public string SourceOfPosting { get; set; }
    }
}
