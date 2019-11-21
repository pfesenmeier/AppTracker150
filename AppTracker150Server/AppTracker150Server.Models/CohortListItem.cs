using AppTracker150Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
    public class CohortListItem
    {
        public int Id { get; set; }
        public string Course { get; set; }
        [Display(Name="Start Date")]
        public DateTime StartDateUtc { get; set; }
        [Display(Name="End Date")]
        public DateTime EndDateUtc { get; set; }
        public bool FullTime { get; set; }
    }
}
