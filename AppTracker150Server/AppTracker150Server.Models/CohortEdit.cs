using AppTracker150Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
    public class CohortEdit
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDateUtc { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDateUtc { get; set; }
        [Required]
        public bool FullTime { get; set; }
        [Required]
        public Course Course{ get; set; }
    }
}
