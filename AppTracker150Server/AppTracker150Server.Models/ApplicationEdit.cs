using AppTracker150Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
    public class ApplicationEdit
    {
        public int ApplicationId { get; set; }
        [Required]
        public ApplicationStatus ApplicationStatus { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string PositionName { get; set; }
        [Required]
        public string JobLink { get; set; }
        [Required]
        public string JobLocation { get; set; }
        [Required]
        public string Research { get; set; }
        [Required]
        public string Contacts { get; set; }
        [Required]
        public string SourceOfPosting { get; set; }
    }
}
