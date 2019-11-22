using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppTracker150Server.Models;
using AppTracker150Server.Services;
using Microsoft.AspNet.Identity;

namespace AppTracker150Server.Controllers
{
    [Authorize(Roles = "Student")]
    [RoutePrefix("Student")]
    public class StudentsController : ApiController
    {
        [Route("Profile")]
        public IHttpActionResult GetProfile(Guid id)
        {
            StudentService studentService = CreateStudentService();
            var profile = studentService.GetStudentById(id);
            return Ok(profile);
        }
        [Route("Profile")]
        public IHttpActionResult PostProfile(StudentCreate student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateStudentService();
            if (!service.CreateStudent(student))
                return InternalServerError();
            return Ok();
        }
        [Route("Profile")]
        public IHttpActionResult PutProfile(StudentEdit student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateStudentService();
            if (!service.UpdateStudent(student))
                return InternalServerError();
            return Ok();
        }

        // GET 
        [Route("Applications")]
        public IHttpActionResult GetApplicationsByStudentId()
        {
            var ApplicationService = CreateApplicationService();
            var applications = ApplicationService.GetApplications(Guid.Parse(User.Identity.GetUserId()));
            return Ok(applications);
        }

        // GET api/values/5
        [Route("Applications")]
        public IHttpActionResult GetApplicationById(int id)
        {
            var ApplicationService = CreateApplicationService();
            var application = ApplicationService.GetApplicationById(id);
            return Ok(application);
        }

        // POST api/values
        [Route("Applications")]
        public IHttpActionResult PostApplication(ApplicationCreate application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateApplicationService();
            if (!service.CreateApplication(application))
                return InternalServerError();
            return Ok();
        }

        // PUT api/values/5
        [Route("Applications")]
        public IHttpActionResult PutApplication(ApplicationEdit application)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateApplicationService();
            if (!service.UpdateApplication(application))
                return InternalServerError();
            return Ok();
        }

        // DELETE api/values/5
        [Route("Applications")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateApplicationService();
            if (!service.DeleteApplication(id))
                return InternalServerError();
            return Ok();
        }

        private ApplicationService CreateApplicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var applicationService = new ApplicationService(userId);
            return applicationService;
        }
        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var studentService = new StudentService(userId);
            return studentService;
        }
    }
}
