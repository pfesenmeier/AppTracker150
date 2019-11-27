using AppTracker150Server.Models;
using AppTracker150Server.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppTracker150Server.Controllers
{   
    [Authorize]
    [RoutePrefix("Cohort")]
    public class CohortController : ApiController
    {
        public IHttpActionResult GetAllCohort()
        {
            CohortService cohortService = CreateCohortService();
            var cohorts = cohortService.GetCohorts();
            return Ok(cohorts);
        }

        public IHttpActionResult GetCohort(int id)
        {
            CohortService cohortService = CreateCohortService();
            var cohorts = cohortService.GetCohortById(id);
            return Ok(cohorts);
        }

        public IHttpActionResult PutCohort(CohortEdit cohort)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCohortService();
            if (!service.UpdateCohort(cohort))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult PostCohort(CohortCreate cohort)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCohortService();
            if (!service.CreateCohort(cohort))
                return InternalServerError();
            return Ok();

        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCohortService();
            if (!service.DeleteCohort(id))
                return InternalServerError();
            return Ok();
        }

        private CohortService CreateCohortService()
        { 
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cohortService = new CohortService(userId);
            return cohortService;
        }



    }
}
