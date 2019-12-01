using AppTracker150Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
    public class ApplicationListItem
    {
        public int ApplicationId { get; set; }
        public string PositionName { get; set; }
        public string CompanyName { get; set; }
        public string ApplicationStatus { get; set; }
        [Display(Name = "Date Applied")]
        public DateTimeOffset DateCreatedUtc { get; set; }
        public string StudentName { get; set; }
        public Guid? StudentId { get; set; }
        public ApplicationStatus? ApplicationEnum { get; set; }
    }
}
