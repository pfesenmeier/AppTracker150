using AppTracker150Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Models
{
    public class CohortDetail
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime EndDateUtc { get; set; }

        public bool FullTime { get; set; }


    }
}
