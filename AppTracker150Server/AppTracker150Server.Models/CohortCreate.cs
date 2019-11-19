using AppTracker150Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
     public class CohortCreate
     {
        [Required]
        public Course Course { get; set; }
        [Required]
        public DateTime StartDateUtc { get; set; }
        [Required]
        public DateTime EndDateUtc { get; set; }
        [Required]
        public bool FullTime { get; set; }

     }
}
