using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Data
{
    public enum Course { DotNet, Javascript, Python, Cybersecurity }
    public class Cohort
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDateUtc { get; set; }
        [Display(Name ="End Date")]
        public DateTime EndDateUtc { get; set; }
        public bool FullTime { get; set; }
        public Course Course { get; set; }
        //public override string ToString() => $"{Course} {StartDateUtc.Month} {StartDateUtc.Year}";
    }
}
