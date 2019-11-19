using AppTracker150Server.Data;
using AppTracker150Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTracker150Server.Services
{
   public class CohortService
   {
        private readonly Guid _userId;

        public CohortService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCohort(CohortCreate model)
        {
            var entity =
                new Cohort()
                {
                    StartDateUtc = model.StartDateUtc,
                    EndDateUtc = model.EndDateUtc,
                    FullTime = model.FullTime,
                    Course = model.Course,
                };
            using (var context = new ApplicationDbContext())
            {
                context.Cohorts.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
        public IEnumerable<CohortListItem> GetCohorts()
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context.Cohorts
                            .Select(
                        e =>
                        new CohortListItem()
                        {
                            Id = e.Id,
                            StartDateUtc = e.StartDateUtc,
                            EndDateUtc = e.EndDateUtc,
                            FullTime = e.FullTime,
                            Course = e.Course,

                        });
                return entity.ToArray();
            }
        }
        public CohortDetail GetCohortById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context.Cohorts
                    .Single(e => e.Id == id);
                return
                    new CohortDetail
                    {
                        Course = entity.Course,
                        Id = entity.Id,
                        FullTime = entity.FullTime,
                        StartDateUtc = entity.StartDateUtc,
                        EndDateUtc = entity.EndDateUtc,
                    };
            }
                
        }
        public bool UpdateCohort(CohortEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                            .Cohorts
                            .Single(e => e.Id == model.Id);
                entity.Course = model.Course;
                entity.Id = model.Id;
                entity.FullTime = model.FullTime;
                entity.StartDateUtc = model.StartDateUtc;
                entity.EndDateUtc = model.EndDateUtc;

                return context.SaveChanges() == 1;
            }

        }
        public bool DeleteCohort(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context.Cohorts
                            .Single(e => e.Id == id);
                context.Cohorts.Remove(entity);
                return context.SaveChanges() == 1;

            }
        }
   }
}

